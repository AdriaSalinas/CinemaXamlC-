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


using System.Collections.Generic;
using System.Windows;
using GUICine2Vista.Peliculas;

namespace Cine
{
    public partial class GUI4 : Window
    {
        private List<Pelicula> Peliculas;
        public GUI4(List<Pelicula> peliculasFiltradas)
        {
            InitializeComponent();
            DataGridPeliculas.ItemsSource = peliculasFiltradas; // Mostrar las películas en la tabla
        }

        private void ReservarButton_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para reservar la película seleccionada
            Pelicula peliculaSeleccionada = (Pelicula)DataGridPeliculas.SelectedItem;

            if (peliculaSeleccionada != null)
            {
                MessageBox.Show($"Has reservado: {peliculaSeleccionada.Titulo}", "Reserva Exitosa");
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una película antes de continuar.", "Error");
            }
        }
    }
}
