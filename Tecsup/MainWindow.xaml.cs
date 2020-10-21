using System;
using System.Windows;
using Business;

namespace Tecsup
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            BPedido bPedido = null;
            try
            {
                bPedido = new BPedido();
                dgvPedido.ItemsSource = bPedido.GetPedidosEntreFechas(Convert.ToDateTime(txtFechaInicio.Text), Convert.ToDateTime(txtFechaFin.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                bPedido = null;
            }
        }

        private void dgvdetallePedido_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            
        }

        private void dgvPedido_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void BtnBuscarPorId_Click(object sender, RoutedEventArgs e)
        {
            BDetallePedido BDetallePedido = null;
            try
            {
                BDetallePedido = new BDetallePedido();
                dgvdetallePedido.ItemsSource = BDetallePedido.GetDetallePedidosPorId(Convert.ToInt32(txtIdPedido.Text));
                txtTotal.Text = BDetallePedido.GetDetalleTotalPorId(Convert.ToInt32(txtIdPedido.Text)).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                BDetallePedido = null;
            }
        }
    }
}
