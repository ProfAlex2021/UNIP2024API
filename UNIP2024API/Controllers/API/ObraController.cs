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
using UNIP2024API.Models;

namespace UNIP2024API.Controllers.API
{
    public class ObraController : ApiController
    {
        private db_dsiEntities db = new db_dsiEntities();

        // GET: api/Obra
        public IQueryable<tb_obra> Gettb_obra()
        {
            return db.tb_obra;
        }

        // GET: api/Obra/5
        [ResponseType(typeof(tb_obra))]
        public async Task<IHttpActionResult> Gettb_obra(int id)
        {
            tb_obra tb_obra = await db.tb_obra.FindAsync(id);
            if (tb_obra == null)
            {
                return NotFound();
            }

            return Ok(tb_obra);
        }

        // PUT: api/Obra/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Puttb_obra(int id, tb_obra tb_obra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tb_obra.id)
            {
                return BadRequest();
            }

            db.Entry(tb_obra).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tb_obraExists(id))
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

        // POST: api/Obra
        [ResponseType(typeof(tb_obra))]
        public async Task<IHttpActionResult> Posttb_obra(tb_obra tb_obra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tb_obra.Add(tb_obra);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tb_obra.id }, tb_obra);
        }

        // DELETE: api/Obra/5
        [ResponseType(typeof(tb_obra))]
        public async Task<IHttpActionResult> Deletetb_obra(int id)
        {
            tb_obra tb_obra = await db.tb_obra.FindAsync(id);
            if (tb_obra == null)
            {
                return NotFound();
            }

            db.tb_obra.Remove(tb_obra);
            await db.SaveChangesAsync();

            return Ok(tb_obra);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tb_obraExists(int id)
        {
            return db.tb_obra.Count(e => e.id == id) > 0;
        }
    }
}