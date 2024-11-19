using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GUICine2Vista.Peliculas
{
    public class Pelicula

    {
        public String Titulo { get; set; }
        public String Idioma { get; set; }
        public List<String> Genero { get; set; } 
        public Int32 Duracion {  get; set; }

        public DateTime FechaInicio {  get; set; }
        public DateTime FechaFin { get; set; }
        
        public Pelicula()
        {

        }

        public String showGenre
        {
            get
                {

                return string.Join(", ", Genero);

            }
        }

        
    
        

    }


}
