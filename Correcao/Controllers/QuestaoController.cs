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
    [RoutePrefix("api/questao")]
    public class QuestaoController : ApiController
    {
        private CorrecaoContext db = new CorrecaoContext();

        // GET: api/Questao
        [Route("getQuestoes")]
        public IQueryable<Questao> GetQuestoes()
        {
            return db.Questoes;
        }

        // GET: api/Questao/5
        [ResponseType(typeof(Questao))]
        [Route("getQuestao/{id}")]
        public IHttpActionResult GetQuestao(int id)
        {
            Questao questao = db.Questoes.Find(id);
            if (questao == null)
            {
                return NotFound();
            }

            return Ok(questao);
        }

        // PUT: api/Questao/5
        [ResponseType(typeof(void))]
        [Route("putQuestao/{id}")]
        public IHttpActionResult PutQuestao(int id, Questao questao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != questao.IdQuestao)
            {
                return BadRequest();
            }

            db.Entry(questao).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestaoExists(id))
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

        // POST: api/Questao
        [ResponseType(typeof(Questao))]
        [Route("postQuestao")]
        public IHttpActionResult PostQuestao(Questao questao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Questoes.Add(questao);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (QuestaoExists(questao.IdQuestao))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = questao.IdQuestao }, questao);
        }

        // DELETE: api/Questao/5
        [ResponseType(typeof(Questao))]
        [Route("deleteQuestao/{id}")]
        public IHttpActionResult DeleteQuestao(int id)
        {
            Questao questao = db.Questoes.Find(id);
            if (questao == null)
            {
                return NotFound();
            }

            db.Questoes.Remove(questao);
            db.SaveChanges();

            return Ok(questao);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuestaoExists(int id)
        {
            return db.Questoes.Count(e => e.IdQuestao == id) > 0;
        }
    }
}