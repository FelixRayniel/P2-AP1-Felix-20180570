using P2_AP1_Felix_20180570.UI.Consultas;
using P2_AP1_Felix_20180570.UI.Registros;
using System;
using System.Collections.Generic;
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

namespace P2_AP1_Felix_20180570
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

      

        private void ConsultaTiposTareasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            CTiposTareas ctt = new CTiposTareas();
            ctt.Show();
        }

        private void RegistroTareasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rProyectos rt = new rProyectos();
            rt.Show();
        }

        private void ConsultaProyectosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cProyectos cp = new cProyectos();
            cp.Show();
        }
    }
}
