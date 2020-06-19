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
    public class RisksController : ApiController
    {
        private nicuEntities db = new nicuEntities();

        // GET: api/Risks
        public IQueryable<Risk> GetRisks()
        {
            return db.Risks;
        }

        // GET: api/Risks/5
        [ResponseType(typeof(Risk))]
        public IHttpActionResult GetRisk(int id)
        {
            Risk risk = db.Risks.Find(id);
            if (risk == null)
            {
                return NotFound();
            }

            return Ok(risk);
        }

        // PUT: api/Risks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRisk(int id, Risk risk)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != risk.RisksId)
            {
                return BadRequest();
            }

            db.Entry(risk).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RiskExists(id))
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

        // POST: api/Risks
        [ResponseType(typeof(Risk))]
        public IHttpActionResult PostRisk(Risk risk)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Risks.Add(risk);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = risk.RisksId }, risk);
        }

        // DELETE: api/Risks/5
        [ResponseType(typeof(Risk))]
        public IHttpActionResult DeleteRisk(int id)
        {
            Risk risk = db.Risks.Find(id);
            if (risk == null)
            {
                return NotFound();
            }

            db.Risks.Remove(risk);
            db.SaveChanges();

            return Ok(risk);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RiskExists(int id)
        {
            return db.Risks.Count(e => e.RisksId == id) > 0;
        }
    }
}