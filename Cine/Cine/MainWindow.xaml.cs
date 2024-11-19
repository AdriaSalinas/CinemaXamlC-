using Cine.Usuario;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Cine.Usuario;
using GUICine2Vista.Peliculas;

namespace Cine
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<User> listUsers { get; set; }
        public List<Pelicula> Peliculas { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            listUsers = new ObservableCollection<User>();
            listUsers.Add(new User("Paco", "Paco@gmail.com", "123"));
            listUsers.Add(new User("Jose", "Jose@gmail.com", "12"));
            listUsers.Add(new User("a", "a", "a"));

            // Crear la lista de películas
            Peliculas = new List<Pelicula>
        {
            new Pelicula()
            {
                Titulo = "La Aventura Espacial",
                Idioma = "Español",
                Genero = new List<string> { "Ciencia Ficción", "Aventura" },
                Duracion = 120,
                FechaInicio = new DateTime(2024, 10, 10),
                FechaFin = new DateTime(2024, 10, 20)
            },
            new Pelicula()
            {
                Titulo = "El Último Samurai",
                Idioma = "Inglés",
                Genero = new List<string> { "Acción", "Drama" },
                Duracion = 150,
                FechaInicio = new DateTime(2024, 10, 15),
                FechaFin = new DateTime(2024, 10, 30)
            },
            new Pelicula()
            {
                Titulo = "Cazadores de Sombras",
                Idioma = "Español",
                Genero = new List<string> { "Fantasía", "Aventura" },
                Duracion = 130,
                FechaInicio = new DateTime(2024, 10, 12),
                FechaFin = new DateTime(2024, 10, 28)
            },
            new Pelicula()
            {
                Titulo = "La Vida es Bella",
                Idioma = "Italiano",
                Genero = new List<string> { "Drama", "Comedia" },
                Duracion = 116,
                FechaInicio = new DateTime(2024, 10, 5),
                FechaFin = new DateTime(2024, 10, 15)
            },
            new Pelicula()
            {
                Titulo = "Inception",
                Idioma = "Inglés",
                Genero = new List<string> { "Ciencia Ficción", "Thriller" },
                Duracion = 148,
                FechaInicio = new DateTime(2024, 10, 20),
                FechaFin = new DateTime(2024, 11, 5)
            }
        };

            DataContext = this;
        

    }




    private void Button_Click(object sender, RoutedEventArgs e)
        {
            string nameUser = LoginUserTB.Text;
            string email = LoginEmailTB.Text;
            string pass = LoginPassTB.Text;
            int sala  = 1;
            
            
            User.LogicaUser();
            if (User.VerificarUsuario(nameUser,email,pass))
                {
                SalaCine salacine = new SalaCine(sala); 
                TablasUser tablasuser = new TablasUser (Peliculas);
                salacine.Show();
                this.Close();
            }
            else 
            {
                MessageBox.Show("Usuario o contraseña incorrecta");
            }
  
        }
 

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void LoginPassTB_Copiar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void LoginPassTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void LoginPassTB_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

    }
}
