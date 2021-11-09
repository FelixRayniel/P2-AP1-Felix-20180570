using P2_AP1_Felix_20180570.BLL;
using P2_AP1_Felix_20180570.Entidades;
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
using System.Windows.Shapes;

namespace P2_AP1_Felix_20180570.UI.Consultas
{
    /// <summary>
    /// Lógica de interacción para cProyectos.xaml
    /// </summary>
    public partial class cProyectos : Window
    {
        public cProyectos()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Proyectos>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: 
                        listado = ProyectosBLL.GetList(e => e.ProyectoID == Utilidades.ToInt(CriterioTextBox.Text));
                        break;

                    case 1:
                        listado = ProyectosBLL.GetList(p => p.Descripcion.ToLower().Contains(CriterioTextBox.Text.ToLower()));
                        break;


                }
            }
            else
            {
                listado = ProyectosBLL.GetList(c => true);
            }

            if (DesdeDataPicker.SelectedDate != null)
                listado = ProyectosBLL.GetList(c => c.Fecha.Date >= DesdeDataPicker.SelectedDate);

            if (HastaDatePicker.SelectedDate != null)
                listado = ProyectosBLL.GetList(c => c.Fecha.Date <= HastaDatePicker.SelectedDate);

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }


    }
}

