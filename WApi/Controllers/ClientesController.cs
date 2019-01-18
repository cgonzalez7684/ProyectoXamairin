using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WApi.Models;

namespace WApi.Controllers
{
    public class ClientesController : ApiController
    {
        private ViewQEntities db = new ViewQEntities();

        // GET: api/Clientes
        [HttpGet]
        public List<Clientes> GetClientes()
        {
            return db.Clientes.ToList();
        }

        [HttpGet]
        [ActionName("InfoCliente")]
        public List<object> InfoCliente(string id)
        {
            IEnumerable<object> ListadoCreditos = (from Ope in db.Creditos
                                                   join Cli in db.Clientes
                                                        on Ope.CodCliente equals Cli.CodCliente
                                                   where Cli.Identificacion == id
                                                   select new
                                                   {
                                                       Operacion = Ope.Operacion,
                                                       MontoOperacion = Ope.MontoOperacion,
                                                       SaldoActual = Ope.SaldoActual,
                                                       Tasa = Ope.Tasa,
                                                       Plazo = Ope.Plazo
                                                   }
                                                   );

            IEnumerable<object> Listado = (from Cli in db.Clientes
                                           join Infor in db.InfoClientes
                                               on Cli.CodCliente equals Infor.CodCliente
                                           where Cli.Identificacion == id
                                           select new
                                           {
                                               NombreCliente = Cli.NomCliente + " " + Cli.Ape1Cliente + " " + Cli.Ape2Cliente,
                                               Institucion = Infor.Institucion.ToUpper(),
                                               NumCreditos = Infor.NumCreditos,
                                               NumAhorros = Infor.NumAhorros,
                                               NumInversiones = Infor.NumInversiones,
                                               Afiliacion = Cli.AFILIACION,
                                               Fidelidad = Infor.AnosFidelidad,
                                               CatSugef = Infor.CatSugef,
                                               Cph = Infor.CPH,
                                               Cpc = Infor.CPC,
                                               Operaciones = ListadoCreditos
                                           });
            return Listado.ToList();
        }

        // GET: api/Clientes/5
        [ResponseType(typeof(Clientes))]
        public async Task<IHttpActionResult> GetClientes(int id)
        {
            Clientes clientes = await db.Clientes.FindAsync(id);
            if (clientes == null)
            {
                return NotFound();
            }

            return Ok(clientes);
        }

        // PUT: api/Clientes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutClientes(int id, Clientes clientes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clientes.CodCliente)
            {
                return BadRequest();
            }

            db.Entry(clientes).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Clientes
        [ResponseType(typeof(Clientes))]
        public async Task<IHttpActionResult> PostClientes(Clientes clientes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Clientes.Add(clientes);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = clientes.CodCliente }, clientes);
        }

        // DELETE: api/Clientes/5
        [ResponseType(typeof(Clientes))]
        public async Task<IHttpActionResult> DeleteClientes(int id)
        {
            Clientes clientes = await db.Clientes.FindAsync(id);
            if (clientes == null)
            {
                return NotFound();
            }

            db.Clientes.Remove(clientes);
            await db.SaveChangesAsync();

            return Ok(clientes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientesExists(int id)
        {
            return db.Clientes.Count(e => e.CodCliente == id) > 0;
        }
    }
}