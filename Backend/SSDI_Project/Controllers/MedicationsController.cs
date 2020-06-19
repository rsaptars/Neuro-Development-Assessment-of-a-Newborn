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
    public class MedicationsController : ApiController
    {
        private nicuEntities db = new nicuEntities();

        // GET: api/Medications
        public IQueryable<Medication> GetMedications()
        {
            return db.Medications;
        }

        // GET: api/Medications/5
        [ResponseType(typeof(Medication))]
        public IHttpActionResult GetMedication(string id)
        {
            Medication medication = db.Medications.Find(id);
            if (medication == null)
            {
                return NotFound();
            }

            return Ok(medication);
        }

        // PUT: api/Medications/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMedication(string id, Medication medication)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medication.MRDno)
            {
                return BadRequest();
            }

            db.Entry(medication).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicationExists(id))
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

        // POST: api/Medications
        [ResponseType(typeof(Medication))]
        public IHttpActionResult PostMedication(Medication medication)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //if (PatientExists(medication.Patient.MRDno))
            //{
                db.Medications.Add(medication);
            //}         

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MedicationExists(medication.MRDno))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = medication.MRDno }, medication);
        }

        private bool PatientExists(string mRDno)
        {
            return db.Patients.Count(e => e.MRDno == mRDno) > 0;
        }

        // DELETE: api/Medications/5
        [ResponseType(typeof(Medication))]
        public IHttpActionResult DeleteMedication(string id)
        {
            Medication medication = db.Medications.Find(id);
            if (medication == null)
            {
                return NotFound();
            }

            db.Medications.Remove(medication);
            db.SaveChanges();

            return Ok(medication);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MedicationExists(string id)
        {
            return db.Medications.Count(e => e.MRDno == id) > 0;
        }
    }
}