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
    /// Lógica de interacción para CTiposTareas.xaml
    /// </summary>
    public partial class CTiposTareas : Window
    {
        public CTiposTareas()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<TiposTareas>();
            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = TiposTareasBLL.GetList(t => t.TipoTareaID == Utilidades.ToInt(CriterioTextBox.Text));
                        break;

                    case 1:
                        listado = TiposTareasBLL.GetList(t => t.TipoTarea.ToLower().Contains(CriterioTextBox.Text.ToLower()));
                        break;
                }
            }
            else
            {
                listado = TiposTareasBLL.GetList(c => true);
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;

        }
    }
}
