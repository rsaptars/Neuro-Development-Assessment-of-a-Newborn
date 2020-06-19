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
    public class ImmunizationsController : ApiController
    {
        private nicuEntities db = new nicuEntities();

        // GET: api/Immunizations
        public IQueryable<Immunization> GetImmunizations()
        {
            return db.Immunizations;
        }

        // GET: api/Immunizations/5
        [ResponseType(typeof(Immunization))]
        public IHttpActionResult GetImmunization(string id)
        {
            Immunization immunization = db.Immunizations.Find(id);
            if (immunization == null)
            {
                return NotFound();
            }

            return Ok(immunization);
        }

        // PUT: api/Immunizations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutImmunization(string id, Immunization immunization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != immunization.MRDno)
            {
                return BadRequest();
            }

            db.Entry(immunization).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImmunizationExists(id))
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

        // POST: api/Immunizations
        [ResponseType(typeof(Immunization))]
        public IHttpActionResult PostImmunization(Immunization immunization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Immunizations.Add(immunization);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ImmunizationExists(immunization.MRDno))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = immunization.MRDno }, immunization);
        }

        // DELETE: api/Immunizations/5
        [ResponseType(typeof(Immunization))]
        public IHttpActionResult DeleteImmunization(string id)
        {
            Immunization immunization = db.Immunizations.Find(id);
            if (immunization == null)
            {
                return NotFound();
            }

            db.Immunizations.Remove(immunization);
            db.SaveChanges();

            return Ok(immunization);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ImmunizationExists(string id)
        {
            return db.Immunizations.Count(e => e.MRDno == id) > 0;
        }
    }
}