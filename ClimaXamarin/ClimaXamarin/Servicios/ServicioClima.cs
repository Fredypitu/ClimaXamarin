using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ClimaXamarin.Clases;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ClimaXamarin.Servicios
{
    public static class ServicioClima
    {
        static readonly string key = "1be67513305e2ea435c7c0fbdfb244a4";
        public static async Task<Clima> ConsultarClima(string pCiudad)
        {
            var conexion = $"http://api.openweathermap.org/data/2.5/weather?q={pCiudad}&appid={key}";

            using (var cliente = new HttpClient())
            {
                var peticion = await cliente.GetAsync(conexion);
                if (peticion != null)
                {
                    var json = await peticion.Content.ReadAsStringAsync();
                    var datos = (JContainer)JsonConvert.DeserializeObject(json);
                    if (datos["weather"]!=null)
                    {
                        var clima = new Clima();
                        clima.Titulo = (string)datos["name"];
                        clima.Temperatura = ((float)datos["main"]["temp"] - 273.15).ToString("N2") + " °C";
                        clima.Viento = (string)datos["wind"]["speed"] + " mph";
                        clima.Humedad = (string)datos["main"]["humidity"] + " %";
                        clima.Visibilidad = (string)datos["weather"][0]["main"];

                        return clima;
                    }
                }
            }
            return default;
        }
    }
}
