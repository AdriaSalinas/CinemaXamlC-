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
        public string user { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public Role UserRole { get; set; }

        public User(string user, string email, string password, Role userRole) // Aquí está la coma
        {
            this.user = user;
            this.email = email;
            this.password = password;
            this.UserRole = userRole;
        }

        public Role GetRole()
        {
            return UserRole;
        }

        public static ObservableCollection<User> listUsers { get; set; }

        public static void LogicaUser()
        {
            listUsers = new ObservableCollection<User>();
            listUsers.Add(new User("Paco", "Paco@gmail.com", "123", Role.Admin));
            listUsers.Add(new User("Jose", "Jose@gmail.com", "12", Role.User));
            listUsers.Add(new User("a", "a", "a", Role.User));
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
