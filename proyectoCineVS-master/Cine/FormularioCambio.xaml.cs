using GUICine2Vista.Peliculas;
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

namespace Cine
{
    /// <summary>
    /// Lógica de interacción para FormularioCambio.xaml
    /// </summary>
    public partial class FormularioCambio : Window
    {
        public FormularioCambio()
        {
            InitializeComponent();
        }

        private void addMovieBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                // Verificar que los campos sean válidos antes de continuar
                if (!ValidarCampos())
                    return;

                // Crear la película
                Pelicula peli = new Pelicula
                {
                    Titulo = TituloTextBox.Text,
                    Idioma = IdiomaTextBox.Text,
                    Duracion = int.Parse(DuracionTextBox.Text),
                    Sala = int.Parse(SalaTextBox.Text),
                    FechaInicio = FechaInicioPicker.SelectedDate.Value,
                    FechaFin = FechaFinPicker.SelectedDate.Value,
                    Genero = GeneroListBox.SelectedItems.Cast<ListBoxItem>().Select(item => item.Content.ToString()).ToList()
                };

                // (Agregar a lista, base de datos, etc.)
                MessageBox.Show($"Película '{peli.Titulo}' agregada correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, verifica que los campos numéricos (Duración, Sala) contengan valores válidos.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        public void closeFormBtn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(TituloTextBox.Text) ||
                string.IsNullOrWhiteSpace(IdiomaTextBox.Text) ||
                string.IsNullOrWhiteSpace(DuracionTextBox.Text) ||
                string.IsNullOrWhiteSpace(SalaTextBox.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos de texto.", "Campos vacíos", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (FechaInicioPicker.SelectedDate == null || FechaFinPicker.SelectedDate == null)
            {
                MessageBox.Show("Por favor, selecciona ambas fechas (inicio y fin).", "Fechas incompletas", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }

    }
}
