using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;


namespace Cine.Usuario
{

    public class User
    {


        public String user { get; set; }
        public String email { get; set; }
        public String password { get; set; }


        public User(string user, String email, string password)
        {
            this.user = user;
            this.email = email;
            this.password = password;


        }

      

        public static ObservableCollection<User> listUsers { get; set; }
        public static void LogicaUser()
        {
            listUsers = new ObservableCollection<User>();
            listUsers.Add(new User("Paco", "Paco@gmail.com", "123"));
            listUsers.Add(new User("Jose", "Jose@gmail.com", "12"));
            listUsers.Add(new User("a", "a", "a"));
           
        }
        public static bool VerificarUsuario(string user, string email, string password)
        {
            foreach (var usuario in listUsers)
            {
                if (usuario.user == user && usuario.email == email && usuario.password == password)
                {
                    return true; // Usuario encontrado
                }
            }
            return false;



        }
    }
}

