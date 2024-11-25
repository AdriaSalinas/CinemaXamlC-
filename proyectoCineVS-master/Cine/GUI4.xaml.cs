using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using GUICine2Vista.Peliculas;

namespace Cine
{
    public partial class GUI4 : Window
    {
        private List<Pelicula> Peliculas;
        private int SalaSeleccionada; 

        public GUI4(List<Pelicula> peliculasFiltradas)
        {
            InitializeComponent();
            DataGridPeliculas.ItemsSource = peliculasFiltradas; 
            SalaSeleccionada = -1; 
        }

        private void DataGridPeliculas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Obtén la película seleccionada desde el DataGrid
            var peliculaSeleccionada = DataGridPeliculas.SelectedItem as Pelicula;

            // Verifica que no sea nulo antes de acceder a sus propiedades
            if (peliculaSeleccionada != null)
            {
                SalaSeleccionada = peliculaSeleccionada.Sala; // Asignar el número de sala
                MessageBox.Show($"Has seleccionado la película '{peliculaSeleccionada.Titulo}' de la Sala {SalaSeleccionada}");
            }
            else
            {
                SalaSeleccionada = -1; // Reinicia si no hay selección válida
            }
        }



        private void ReservarButton_Click(object sender, RoutedEventArgs e)
        {
            if (SalaSeleccionada == -1)
            {
                MessageBox.Show("Por favor, selecciona una película primero.", "Error");
                return;
            }

          
            try
            {
                SalaCine salaCine = new SalaCine(SalaSeleccionada);
                MessageBox.Show($"Abriendo configuración para la Sala {SalaSeleccionada}", "Éxito");
                salaCine.ShowDialog(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir la sala: {ex.Message}", "Error");
            }
        }
    }
}