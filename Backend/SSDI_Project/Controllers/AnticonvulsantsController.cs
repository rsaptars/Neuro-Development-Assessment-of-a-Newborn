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
using SSDI_Project;

namespace SSDI_Project.Controllers
{
    public class AnticonvulsantsController : ApiController
    {
        private nicuEntities db = new nicuEntities();

        // GET: api/Anticonvulsants
        public IQueryable<Anticonvulsant> GetAnticonvulsants()
        {
            return db.Anticonvulsants;
        }

        // GET: api/Anticonvulsants/5
        [ResponseType(typeof(Anticonvulsant))]
        public IHttpActionResult GetAnticonvulsant(string id)
        {
            Anticonvulsant anticonvulsant = db.Anticonvulsants.Find(id);
            if (anticonvulsant == null)
            {
                return NotFound();
            }

            return Ok(anticonvulsant);
        }

        // PUT: api/Anticonvulsants/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAnticonvulsant(string id, Anticonvulsant anticonvulsant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != anticonvulsant.MRDno)
            {
                return BadRequest();
            }

            db.Entry(anticonvulsant).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnticonvulsantExists(id))
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

        // POST: api/Anticonvulsants
        [ResponseType(typeof(Anticonvulsant))]
        public IHttpActionResult PostAnticonvulsant(Anticonvulsant anticonvulsant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Anticonvulsants.Add(anticonvulsant);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AnticonvulsantExists(anticonvulsant.MRDno))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = anticonvulsant.MRDno }, anticonvulsant);
        }

        // DELETE: api/Anticonvulsants/5
        [ResponseType(typeof(Anticonvulsant))]
        public IHttpActionResult DeleteAnticonvulsant(string id)
        {
            Anticonvulsant anticonvulsant = db.Anticonvulsants.Find(id);
            if (anticonvulsant == null)
            {
                return NotFound();
            }

            db.Anticonvulsants.Remove(anticonvulsant);
            db.SaveChanges();

            return Ok(anticonvulsant);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AnticonvulsantExists(string id)
        {
            return db.Anticonvulsants.Count(e => e.MRDno == id) > 0;
        }
    }
}