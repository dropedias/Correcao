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
using Correcao.Models;

namespace Correcao.Controllers
{
    public class CandidatoController : ApiController
    {
        private CorrecaoContext db = new CorrecaoContext();

        // GET: api/Candidato
        public IQueryable<Candidato> GetCandidatos()
        {
            return db.Candidatos;
        }

        // GET: api/Candidato/5
        [ResponseType(typeof(Candidato))]
        public IHttpActionResult GetCandidato(int id)
        {
            Candidato candidato = db.Candidatos.Find(id);
            if (candidato == null)
            {
                return NotFound();
            }

            return Ok(candidato);
        }

        // PUT: api/Candidato/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCandidato(int id, Candidato candidato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != candidato.IdCandidato)
            {
                return BadRequest();
            }

            db.Entry(candidato).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidatoExists(id))
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

        // POST: api/Candidato
        [ResponseType(typeof(Candidato))]
        public IHttpActionResult PostCandidato(Candidato candidato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Candidatos.Add(candidato);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = candidato.IdCandidato }, candidato);
        }

        // DELETE: api/Candidato/5
        [ResponseType(typeof(Candidato))]
        public IHttpActionResult DeleteCandidato(int id)
        {
            Candidato candidato = db.Candidatos.Find(id);
            if (candidato == null)
            {
                return NotFound();
            }

            db.Candidatos.Remove(candidato);
            db.SaveChanges();

            return Ok(candidato);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CandidatoExists(int id)
        {
            return db.Candidatos.Count(e => e.IdCandidato == id) > 0;
        }
    }
}