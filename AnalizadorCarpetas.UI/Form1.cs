using System;
using System.Windows.Forms;
using System.Threading;
using AnalizadorCarpetas.BE;
using AnalizadorCarpetas.BLL;


namespace AnalizadorCarpetas.UI
{
    public partial class Form1 : Form
    {
        private EscaneoService servicio = new EscaneoService();
        private AnalizadorIA analizadorIA = new AnalizadorIA();
        private CancellationTokenSource cancelacion;
        private ResultadoEscaneo ultimoResultado;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
        {

        }

        private void btnExaminar_Click(object sender, System.EventArgs e)
        {
            using (FolderBrowserDialog dialogo = new FolderBrowserDialog())
            {
                if (dialogo.ShowDialog() == DialogResult.OK)
                {
                    txtRuta.Text = dialogo.SelectedPath;
                }
            }
        }

        private async void btnIniciar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRuta.Text))
            {
                MessageBox.Show("Seleccione una carpeta.");
                return;
            }

            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;

            cancelacion = new CancellationTokenSource();
            Progress<int> progreso = new Progress<int>(valor => progressBar1.Value = valor);

            try
            {
                ResultadoEscaneo resultado;

                if (rbThread.Checked)
                {
                    // Thread bloquea el hilo pero se ejecuta de forma síncrona controlada
                    resultado = servicio.EscanearThread(
                        txtRuta.Text,
                        progreso,
                        cancelacion.Token);
                }
                else if (rbTask.Checked)
                {
                    // Usamos await en lugar de .Result para evitar deadlocks en la UI
                    resultado = await servicio.EscanearTask(
                        txtRuta.Text,
                        progreso,
                        cancelacion.Token);
                }
                else if (rbAsync.Checked)
                {
                    resultado = await servicio.EscanearAsync(
                        txtRuta.Text,
                        progreso,
                        cancelacion.Token);
                }
                else // Secuencial (por defecto)
                {
                    resultado = servicio.EscanearSecuencial(
                        txtRuta.Text,
                        progreso,
                        cancelacion.Token);
                }

                ultimoResultado = resultado;

                lblCantidadArchivos.Text = resultado.CantidadArchivos.ToString();
                lblCantidadCarpetas.Text = resultado.CantidadCarpetas.ToString();
                lblTamañoTotal.Text = resultado.TamañoTotal.ToString() + " bytes";
                lblTiempo.Text = resultado.TiempoProceso.ToString();
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("El proceso fue cancelado.");
                progressBar1.Value = 0;
            }
            finally
            {
                cancelacion?.Dispose();
                cancelacion = null;
            }
        }

        private void lblTiempo_Click(object sender, System.EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, System.EventArgs e)
        {

        }

        private void rbTask_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtRuta_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnAnalizarIA_Click(object sender, EventArgs e)
        {
            if (ultimoResultado == null)
            {
                MessageBox.Show(
                    "Primero debe realizar un escaneo."
                );

                return;
            }

            try
            {
                txtAnalisisIA.Text = "Analizando la carpeta con IA...";

                string resumen =
                    servicio.CrearResumenParaIA(ultimoResultado);

                string analisis =
                    await analizadorIA.AnalizarAsync(resumen);

                txtAnalisisIA.Text = analisis;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo realizar el análisis con IA.\n\n"
                    + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                txtAnalisisIA.Clear();
            }
        }
    }
}
