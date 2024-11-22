using Cine.Usuario;
using GUICine2Vista.Peliculas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Lógica de interacción para TablasUser.xaml
    /// </summary>
    public partial class TablasUser : Window
    {
        private Role rolUser;
        public List<Pelicula> Peliculas { get; set; }

        public TablasUser(List<Pelicula> peliculas, Role rol)
        {
            InitializeComponent();
            Peliculas = new List<Pelicula>(peliculas);
            DataContext = this;
            rolUser = rol;
            InitializeUI();
        }

        private void InitializeUI()
        {
            if (rolUser != Role.Admin)
            {
                AddMovies.Visibility = Visibility.Collapsed;
            }
        }




        private void addMovieBtn(Object sender, RoutedEventArgs e)
        {
            FormularioCambio formulario = new FormularioCambio();

            formulario.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void logOutClick(object sender, RoutedEventArgs e)
        {
            var MainWindow = new MainWindow();

            MainWindow.Show();

            this.Close();

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ButtonAbrirGUI3_Click(object sender, RoutedEventArgs e)
        {
            // Crear una nueva instancia de GUI3
            GUI3 nuevaVentana = new GUI3(Peliculas);
            // Mostrar la ventana como modal
            nuevaVentana.ShowDialog();
        }
    }
}
