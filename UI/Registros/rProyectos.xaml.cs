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

namespace P2_AP1_Felix_20180570.UI.Registros
{
    /// <summary>
    /// Lógica de interacción para rTareas.xaml
    /// </summary>
    public partial class rProyectos : Window
    {
        private Proyectos proyecto = new Proyectos();
        public rProyectos()
        {
            this.DataContext = proyecto;
            InitializeComponent();
            TipoTareaComboBox.ItemsSource = TiposTareasBLL.GetTipoTarea();
            TipoTareaComboBox.SelectedValuePath = "TipoTareaID";
            TipoTareaComboBox.DisplayMemberPath = "TipoTarea";



        }

        public void Limpiar()
        {
            this.proyecto = new Proyectos();
            this.DataContext = proyecto;
        }

        public void Cargar()
        {
            this.DataContext = null;
            this.DataContext = proyecto;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Proyectos proyectoEncontrado = ProyectosBLL.Buscar(proyecto.ProyectoID);

            if (proyectoEncontrado != null)
            {
                proyecto = proyectoEncontrado;
                Cargar();
            } else
            {
                Limpiar();
                MessageBox.Show("NO SE PUEDO ENCONTRAR EL REGISTRO EN LA BASE DE DATOS", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }


        }

        private void AgregarFilaButton_Click(object sender, RoutedEventArgs e)
        {
            proyecto.DetalleTarea.Add(new TareasDetalle(
                (int)TipoTareaComboBox.SelectedValue, RequerimientoTextBox.Text, 
                int.Parse(TiempoTextBox.Text), (TiposTareas)TipoTareaComboBox.SelectedItem
                ));

            proyecto.TiempoTotal += int.Parse(TiempoTextBox.Text);

            Cargar();
        }

        private void RemoverFilaButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
            {
                return;
            }
            var paso = ProyectosBLL.Guardar(proyecto);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("SE HA GUARDADO EL PROYECTO EXISTOSAMENTE", "Existo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("NO SE PUDO GUARDAR EL PROYECTO", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            Proyectos proyectoEncontrado = ProyectosBLL.Buscar(proyecto.ProyectoID);

            if (proyectoEncontrado == null)
            {
                MessageBox.Show("NO SE PUEDO ENCONTRAR EL REGISTRO EN LA BASE DE DATOS", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                ProyectosBLL.Eliminar(proyecto.ProyectoID);
                MessageBox.Show("PROYECTO ELIMINADO", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }

        }

        private bool Validar()
        {
            bool esValido = true;

            if (ProyectoIDTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("INGRESE UN NUMERO DE ID", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning); 
            }

            if (DescripcionTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("INGRESE UNA DESCRIPCION", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            
            return esValido;
        }
    }
}
