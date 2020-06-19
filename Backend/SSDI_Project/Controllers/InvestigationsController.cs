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
    public class InvestigationsController : ApiController
    {
        private nicuEntities db = new nicuEntities();

        // GET: api/Investigations
        public IQueryable<Investigation> GetInvestigations()
        {
            return db.Investigations;
        }

        // GET: api/Investigations/5
        [ResponseType(typeof(Investigation))]
        public IHttpActionResult GetInvestigation(string id)
        {
            Investigation investigation = db.Investigations.Find(id);
            if (investigation == null)
            {
                return NotFound();
            }

            return Ok(investigation);
        }

        // PUT: api/Investigations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInvestigation(string id, Investigation investigation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != investigation.MRDno)
            {
                return BadRequest();
            }

            db.Entry(investigation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvestigationExists(id))
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

        // POST: api/Investigations
        [ResponseType(typeof(Investigation))]
        public IHttpActionResult PostInvestigation(Investigation investigation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Investigations.Add(investigation);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (InvestigationExists(investigation.MRDno))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = investigation.MRDno }, investigation);
        }

        // DELETE: api/Investigations/5
        [ResponseType(typeof(Investigation))]
        public IHttpActionResult DeleteInvestigation(string id)
        {
            Investigation investigation = db.Investigations.Find(id);
            if (investigation == null)
            {
                return NotFound();
            }

            db.Investigations.Remove(investigation);
            db.SaveChanges();

            return Ok(investigation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InvestigationExists(string id)
        {
            return db.Investigations.Count(e => e.MRDno == id) > 0;
        }
    }
}