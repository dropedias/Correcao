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
    public class ImagemController : ApiController
    {
        private CorrecaoContext db = new CorrecaoContext();

        // GET: api/Imagem
        public IQueryable<Imagem> GetImagens()
        {
            return db.Imagens;
        }

        // GET: api/Imagem/5
        [ResponseType(typeof(Imagem))]
        public IHttpActionResult GetImagem(int id)
        {
            Imagem imagem = db.Imagens.Find(id);
            if (imagem == null)
            {
                return NotFound();
            }

            return Ok(imagem);
        }

        // PUT: api/Imagem/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutImagem(int id, Imagem imagem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != imagem.IdImagem)
            {
                return BadRequest();
            }

            db.Entry(imagem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImagemExists(id))
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

        // POST: api/Imagem
        [ResponseType(typeof(Imagem))]
        public IHttpActionResult PostImagem(Imagem imagem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Imagens.Add(imagem);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = imagem.IdImagem }, imagem);
        }

        // DELETE: api/Imagem/5
        [ResponseType(typeof(Imagem))]
        public IHttpActionResult DeleteImagem(int id)
        {
            Imagem imagem = db.Imagens.Find(id);
            if (imagem == null)
            {
                return NotFound();
            }

            db.Imagens.Remove(imagem);
            db.SaveChanges();

            return Ok(imagem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ImagemExists(int id)
        {
            return db.Imagens.Count(e => e.IdImagem == id) > 0;
        }
    }
}