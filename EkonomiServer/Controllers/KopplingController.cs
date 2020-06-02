using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using EkonomiDataAccess1;

namespace EkonomiServer.Controllers
{
    public class KopplingController : ApiController
    {
        private EkonomiMarknadsforingDBEntities db = new EkonomiMarknadsforingDBEntities();

        // GET: api/Koppling
        public IQueryable<SchemaKoppling> GetSchemaKoppling()
        {
            return db.SchemaKoppling;
        }

        // GET: api/Koppling/5
        [ResponseType(typeof(SchemaKoppling))]
        public IHttpActionResult GetSchemaKoppling(int id)
        {
            SchemaKoppling schemaKoppling = db.SchemaKoppling.Find(id);
            if (schemaKoppling == null)
            {
                return NotFound();
            }

            return Ok(schemaKoppling);
        }

        // PUT: api/Koppling/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSchemaKoppling(int id, SchemaKoppling schemaKoppling)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != schemaKoppling.Id)
            {
                return BadRequest();
            }

            db.Entry(schemaKoppling).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchemaKopplingExists(id))
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

        // POST: api/Koppling
        [ResponseType(typeof(SchemaKoppling))]
        public IHttpActionResult PostSchemaKoppling(SchemaKoppling schemaKoppling)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SchemaKoppling.Add(schemaKoppling);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = schemaKoppling.Id }, schemaKoppling);
        }

        // DELETE: api/Koppling/5
        [ResponseType(typeof(SchemaKoppling))]
        public IHttpActionResult DeleteSchemaKoppling(int id)
        {
            SchemaKoppling schemaKoppling = db.SchemaKoppling.Find(id);
            if (schemaKoppling == null)
            {
                return NotFound();
            }

            db.SchemaKoppling.Remove(schemaKoppling);
            db.SaveChanges();

            return Ok(schemaKoppling);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SchemaKopplingExists(int id)
        {
            return db.SchemaKoppling.Count(e => e.Id == id) > 0;
        }
    }
}