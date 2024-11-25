using GUICine2Vista.Peliculas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Cine
{
    public partial class GUI3 : Window
    {
        private List<Pelicula> Peliculas;

        public GUI3(List<Pelicula> peliculas)
        {
            InitializeComponent();
            Peliculas = peliculas ?? new List<Pelicula>();
            DatePickerFecha.SelectedDate = DateTime.Now;
            CargarPeliculas();
        }

        private void CargarPeliculas(List<Pelicula> peliculas = null)
        {
            DataGridPeliculas.Columns.Clear();
            if (peliculas == null)
                peliculas = Peliculas;
            DataGridPeliculas.ItemsSource = peliculas;
        }

        private void ButtonConsultar_Click(object sender, RoutedEventArgs e)
        {
            DateTime? fechaSeleccionada = DatePickerFecha.SelectedDate;
            if (fechaSeleccionada == null)
            {
                MessageBox.Show("Por favor, selecciona una fecha.");
                return;
            }
            MessageBox.Show($"Mostrando películas para el día: {fechaSeleccionada.Value.ToShortDateString()}");
        }

        private void ButtonAplicarFiltros_Click(object sender, RoutedEventArgs e)
        {
            string generoSeleccionado = ((ComboBoxItem)ComboBoxGenero.SelectedItem)?.Content.ToString();
            string idiomaSeleccionado = ((ComboBoxItem)ComboBoxIdioma.SelectedItem)?.Content.ToString();
            MessageBox.Show($"Aplicando filtros: Género: {generoSeleccionado}, Idioma: {idiomaSeleccionado}");
            List<Pelicula> peliculasFiltradas = FiltrarPeliculas(generoSeleccionado, idiomaSeleccionado, DatePickerFecha.SelectedDate);
            CargarPeliculas(peliculasFiltradas);
        }

        private void ButtonLimpiar_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxGenero.SelectedIndex = 0;
            ComboBoxIdioma.SelectedIndex = 0;
            DatePickerFecha.SelectedDate = DateTime.Now;
            CargarPeliculas();
        }

        private void ButtonAbrirGUI4_Click(object sender, RoutedEventArgs e)
        {
            string generoSeleccionado = ((ComboBoxItem)ComboBoxGenero.SelectedItem)?.Content.ToString();
            string idiomaSeleccionado = ((ComboBoxItem)ComboBoxIdioma.SelectedItem)?.Content.ToString();
            DateTime? fechaSeleccionada = DatePickerFecha.SelectedDate;
            List<Pelicula> peliculasFiltradas = FiltrarPeliculas(generoSeleccionado, idiomaSeleccionado, fechaSeleccionada);
            if (peliculasFiltradas.Count > 0)
            {
                GUI4 ventanaGUI4 = new GUI4(peliculasFiltradas);
                ventanaGUI4.ShowDialog();
            }
            else
            {
                MessageBox.Show("No hay películas que coincidan con los filtros seleccionados.", "Sin Resultados");
            }
        }

        private List<Pelicula> FiltrarPeliculas(string genero, string idioma, DateTime? fecha)
        {
            var peliculasFiltradas = Peliculas.Where(p =>
                (genero == "Todos" ||
                 p.Generos.Split(',')
                 .Select(g => g.Trim())
                 .Any(g => g.Equals(genero, StringComparison.OrdinalIgnoreCase))) &&
                (idioma == "Todos" || p.Idioma.Equals(idioma, StringComparison.OrdinalIgnoreCase)) &&
                (!fecha.HasValue || (p.FechaInicio.Date <= fecha.Value.Date && p.FechaFin.Date >= fecha.Value.Date))
            ).ToList();
            return peliculasFiltradas;
        }
    }
}
