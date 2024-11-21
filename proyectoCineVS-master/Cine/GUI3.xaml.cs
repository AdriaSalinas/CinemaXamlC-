using GUICine2Vista.Peliculas;
using System;
using System.Collections.Generic;
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
            Peliculas = peliculas ?? new List<Pelicula>(); // Si 'peliculas' es nulo, inicializa una lista vacía
            DatePickerFecha.SelectedDate = DateTime.Now; // Fecha actual por defecto
            CargarPeliculas(); // Cargar todas las películas al iniciar
        }

        private void CargarPeliculas(List<Pelicula> peliculas = null)
        {
      // Limpiar columnas previas para evitar duplicados
    DataGridPeliculas.Columns.Clear(); 

    // Si no se pasa una lista filtrada, carga todas las películas
    if (peliculas == null)
        peliculas = Peliculas;

    DataGridPeliculas.ItemsSource = peliculas;
        }

        private void ButtonConsultar_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para consultar películas del día seleccionado
            DateTime? fechaSeleccionada = DatePickerFecha.SelectedDate;

            if (fechaSeleccionada == null)
            {
                MessageBox.Show("Por favor, selecciona una fecha.");
                return;
            }

            MessageBox.Show($"Mostrando películas para el día: {fechaSeleccionada.Value.ToShortDateString()}");
            // Aquí puedes actualizar la lista según la fecha seleccionada
        }

        private void ButtonAplicarFiltros_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para aplicar filtros
            string generoSeleccionado = ((ComboBoxItem)ComboBoxGenero.SelectedItem)?.Content.ToString();
            string idiomaSeleccionado = ((ComboBoxItem)ComboBoxIdioma.SelectedItem)?.Content.ToString();

            MessageBox.Show($"Aplicando filtros: Género: {generoSeleccionado}, Idioma: {idiomaSeleccionado}");
            // Aquí puedes filtrar las películas según los criterios seleccionados
            List<Pelicula> peliculasFiltradas = FiltrarPeliculas(generoSeleccionado, idiomaSeleccionado, DatePickerFecha.SelectedDate);
            CargarPeliculas(peliculasFiltradas);
        }

        private void ButtonLimpiar_Click(object sender, RoutedEventArgs e)
        {
            // Restaurar filtros a valores predeterminados
            ComboBoxGenero.SelectedIndex = 0; // "Todos"
            ComboBoxIdioma.SelectedIndex = 0; // "Todos"
            DatePickerFecha.SelectedDate = DateTime.Now;

            CargarPeliculas(); // Volver a cargar todas las películas
        }

        private void ButtonAbrirGUI4_Click(object sender, RoutedEventArgs e)
        {
            // Obtener los criterios seleccionados
            string generoSeleccionado = ((ComboBoxItem)ComboBoxGenero.SelectedItem)?.Content.ToString();
            string idiomaSeleccionado = ((ComboBoxItem)ComboBoxIdioma.SelectedItem)?.Content.ToString();
            DateTime? fechaSeleccionada = DatePickerFecha.SelectedDate;

            // Filtrar las películas con los criterios seleccionados
            List<Pelicula> peliculasFiltradas = FiltrarPeliculas(generoSeleccionado, idiomaSeleccionado, fechaSeleccionada);

            if (peliculasFiltradas.Count > 0)
            {
                // Abre GUI4 pasando las películas filtradas
                GUI4 ventanaGUI4 = new GUI4(peliculasFiltradas);
                ventanaGUI4.ShowDialog(); // ShowDialog para que sea modal
            }
            else
            {
                MessageBox.Show("No hay películas que coincidan con los filtros seleccionados.", "Sin Resultados");
            }
        }

        private List<Pelicula> FiltrarPeliculas(string genero, string idioma, DateTime? fecha)
        {
            // Filtrar según los criterios seleccionados
            var peliculasFiltradas = Peliculas.FindAll(p =>
                (genero == "Todos" || p.Genero.Contains(genero)) && // Verifica si el género está en la lista
                (idioma == "Todos" || p.Idioma == idioma) && // Filtra por idioma
                (!fecha.HasValue || (p.FechaInicio.Date <= fecha.Value.Date && p.FechaFin.Date >= fecha.Value.Date)) // Filtra por fecha
            );

            return peliculasFiltradas;
        }
    }
}