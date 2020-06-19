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
    public class MorbiditiesController : ApiController
    {
        private nicuEntities db = new nicuEntities();

        // GET: api/Morbidities
        public IQueryable<Morbidity> GetMorbidities()
        {
            return db.Morbidities;
        }

        // GET: api/Morbidities/5
        [ResponseType(typeof(Morbidity))]
        public IHttpActionResult GetMorbidity(int id)
        {
            Morbidity morbidity = db.Morbidities.Find(id);
            if (morbidity == null)
            {
                return NotFound();
            }

            return Ok(morbidity);
        }

        // PUT: api/Morbidities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMorbidity(int id, Morbidity morbidity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != morbidity.MorbidityId)
            {
                return BadRequest();
            }

            db.Entry(morbidity).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MorbidityExists(id))
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

        // POST: api/Morbidities
        [ResponseType(typeof(Morbidity))]
        public IHttpActionResult PostMorbidity(Morbidity morbidity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Morbidities.Add(morbidity);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = morbidity.MorbidityId }, morbidity);
        }

        // DELETE: api/Morbidities/5
        [ResponseType(typeof(Morbidity))]
        public IHttpActionResult DeleteMorbidity(int id)
        {
            Morbidity morbidity = db.Morbidities.Find(id);
            if (morbidity == null)
            {
                return NotFound();
            }

            db.Morbidities.Remove(morbidity);
            db.SaveChanges();

            return Ok(morbidity);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MorbidityExists(int id)
        {
            return db.Morbidities.Count(e => e.MorbidityId == id) > 0;
        }
    }
}