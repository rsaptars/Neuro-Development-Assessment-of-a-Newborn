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
    public class DiagnosisController : ApiController
    {
        private nicuEntities db = new nicuEntities();

        // GET: api/Diagnosis
        public IQueryable<Diagnosi> GetDiagnosis()
        {
            return db.Diagnosis;
        }

        // GET: api/Diagnosis/5
        [ResponseType(typeof(Diagnosi))]
        public IHttpActionResult GetDiagnosi(string id)
        {
            Diagnosi diagnosi = db.Diagnosis.Find(id);
            if (diagnosi == null)
            {
                return NotFound();
            }

            return Ok(diagnosi);
        }

        // PUT: api/Diagnosis/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDiagnosi(string id, Diagnosi diagnosi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != diagnosi.MRDno)
            {
                return BadRequest();
            }

            db.Entry(diagnosi).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiagnosiExists(id))
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

        // POST: api/Diagnosis
        [ResponseType(typeof(Diagnosi))]
        public IHttpActionResult PostDiagnosi(Diagnosi diagnosi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Diagnosis.Add(diagnosi);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DiagnosiExists(diagnosi.MRDno))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = diagnosi.MRDno }, diagnosi);
        }

        // DELETE: api/Diagnosis/5
        [ResponseType(typeof(Diagnosi))]
        public IHttpActionResult DeleteDiagnosi(string id)
        {
            Diagnosi diagnosi = db.Diagnosis.Find(id);
            if (diagnosi == null)
            {
                return NotFound();
            }

            db.Diagnosis.Remove(diagnosi);
            db.SaveChanges();

            return Ok(diagnosi);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DiagnosiExists(string id)
        {
            return db.Diagnosis.Count(e => e.MRDno == id) > 0;
        }
    }
}