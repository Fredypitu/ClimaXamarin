using System;
using System.Collections.Generic;
using System.Text;

namespace ClimaXamarin.Clases
{
    public class Clima
    {
        public Clima()
        {
            this.Titulo = string.Empty;
            this.Temperatura = string.Empty;
            this.Viento = string.Empty;
            this.Humedad = string.Empty;
            this.Visibilidad = string.Empty;
        }
        public string Titulo { get; set; }
        public string Temperatura { get; set; }
        public string Viento { get; set; }
        public string Humedad { get; set; }
        public string Visibilidad { get; set; }
    }
}
