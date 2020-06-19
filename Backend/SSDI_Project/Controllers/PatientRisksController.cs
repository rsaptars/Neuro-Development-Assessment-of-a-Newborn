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
    public class PatientRisksController : ApiController
    {
        private nicuEntities db = new nicuEntities();

        // GET: api/PatientRisks
        public IQueryable<PatientRisk> GetPatientRisks()
        {
            return db.PatientRisks;
        }

        // GET: api/PatientRisks/5
        [ResponseType(typeof(PatientRisk))]
        public IHttpActionResult GetPatientRisk(string id)
        {
            PatientRisk patientRisk = db.PatientRisks.Find(id);
            if (patientRisk == null)
            {
                return NotFound();
            }

            return Ok(patientRisk);
        }

        // PUT: api/PatientRisks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPatientRisk(string id, PatientRisk patientRisk)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != patientRisk.MRDno)
            {
                return BadRequest();
            }

            db.Entry(patientRisk).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientRiskExists(id))
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

        // POST: api/PatientRisks
        [ResponseType(typeof(PatientRisk))]
        public IHttpActionResult PostPatientRisk(PatientRisk patientRisk)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PatientRisks.Add(patientRisk);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PatientRiskExists(patientRisk.MRDno))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = patientRisk.MRDno }, patientRisk);
        }

        // DELETE: api/PatientRisks/5
        [ResponseType(typeof(PatientRisk))]
        public IHttpActionResult DeletePatientRisk(string id)
        {
            PatientRisk patientRisk = db.PatientRisks.Find(id);
            if (patientRisk == null)
            {
                return NotFound();
            }

            db.PatientRisks.Remove(patientRisk);
            db.SaveChanges();

            return Ok(patientRisk);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PatientRiskExists(string id)
        {
            return db.PatientRisks.Count(e => e.MRDno == id) > 0;
        }
    }
}