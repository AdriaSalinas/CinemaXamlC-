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

        private void CreateMovieCLick(object sender, RoutedEventArgs e)
        {
            Pelicula peli = new Pelicula();

            peli.Titulo = TituloTextBox.Text;
            peli.Idioma = IdiomaTextBox.Text;
            peli.Duracion = int.Parse(DuracionTextBox.Text);
            peli.FechaInicio = FechaInicioPicker.SelectedDate.Value;
            peli.FechaFin = FechaFinPicker.SelectedDate.Value;

            peli.Genero = new List<string>();
            foreach (var item in GeneroListBox.SelectedItems)
            {
                peli.Genero.Add(item.ToString());
            }
        }
    }
}
