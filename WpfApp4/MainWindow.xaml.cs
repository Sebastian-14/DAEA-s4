using Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp4
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
                dvgPedido.ItemsSource = bPedido.GetPedidosEntreFechas(Convert.ToDateTime(txtFechaInicio.Text), Convert.ToDateTime(txtFechaFin.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("Comunicarse con el administrador");
            }
            finally
            {
                bPedido = null;
            }
        }

        private void dvgPedido_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BDetallePedido bDetallePedido = null;
            
            try
            {
                //int idPedido = 10248;
                //bDetallePedido = new BDetallePedido();
                //dvgDetallePedido.ItemsSource = bDetallePedido.GetDetallePedidoPorId(idPedido);
            }
            catch (Exception)
            {
                MessageBox.Show("Comunicarse con el administrador otra vez");
            }
            finally
            {
                bDetallePedido = null;
            }
        }
    }
}
