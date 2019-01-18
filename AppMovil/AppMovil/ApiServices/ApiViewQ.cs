using System;
using System.Collections.Generic;
using System.Text;

using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace AppMovil.ApiServices
{
    public class ApiViewQ
    {

        public const string WEB_SERVICE_URL = "http://cloud-services.azurewebsites.net/api/products";

        public async Task<Entidades.InfoCliente[]> GetStringAsync(string Cedula)
        {
            //La clase HttpClient implementa la interfaz IDisposable lo que obliga a destruir de alguna forma
            //el objeto que cree con esta clase de forma directa.
            using (HttpClient cliente = new HttpClient())
            {
                //cliente.BaseAddress = new Uri("http://viewq.gearhostpreview.com/api/Clientes/InfoCliente/112070954");
                string apiCgr = "http://viewq.gearhostpreview.com/api/Clientes/InfoCliente/{0}";
                cliente.BaseAddress = new Uri(string.Format(apiCgr, Cedula.Trim()));
                cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")); //Si mi cliente quiere XML pongo text/xml            
                var respuesta = await cliente.GetStringAsync(""); //Vacio ya que en el BaseAddress configure toda la ruta
                var data = JsonConvert.DeserializeObject<Entidades.InfoCliente[]>(respuesta);
                //System.Diagnostics.Debug.WriteLine(data); //Solo para debug
                return data;

            }
        }
    }
}

