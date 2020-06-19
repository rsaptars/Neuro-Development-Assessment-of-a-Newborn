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
    public class MedicationTypesController : ApiController
    {
        private nicuEntities db = new nicuEntities();

        // GET: api/MedicationTypes
        public IQueryable<MedicationType> GetMedicationTypes()
        {
            return db.MedicationTypes;
        }

        // GET: api/MedicationTypes/5
        [ResponseType(typeof(MedicationType))]
        public IHttpActionResult GetMedicationType(int id)
        {
            MedicationType medicationType = db.MedicationTypes.Find(id);
            if (medicationType == null)
            {
                return NotFound();
            }

            return Ok(medicationType);
        }

        // PUT: api/MedicationTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMedicationType(int id, MedicationType medicationType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medicationType.MedicationTypeId)
            {
                return BadRequest();
            }

            db.Entry(medicationType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicationTypeExists(id))
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

        // POST: api/MedicationTypes
        [ResponseType(typeof(MedicationType))]
        public IHttpActionResult PostMedicationType(MedicationType medicationType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MedicationTypes.Add(medicationType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = medicationType.MedicationTypeId }, medicationType);
        }

        // DELETE: api/MedicationTypes/5
        [ResponseType(typeof(MedicationType))]
        public IHttpActionResult DeleteMedicationType(int id)
        {
            MedicationType medicationType = db.MedicationTypes.Find(id);
            if (medicationType == null)
            {
                return NotFound();
            }

            db.MedicationTypes.Remove(medicationType);
            db.SaveChanges();

            return Ok(medicationType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MedicationTypeExists(int id)
        {
            return db.MedicationTypes.Count(e => e.MedicationTypeId == id) > 0;
        }
    }
}