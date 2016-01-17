using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using OnlineExamService.DbContexts;
using OnlineExamService.Models;
using System.Web.Http.Cors;

namespace OnlineExamService.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class McqAnswersController : ApiController
    {
        private ExamDbContext db = new ExamDbContext();

        // GET: api/McqAnswers
        public IQueryable<McqAnswer> GetMcqAnswers()
        {
            return db.McqAnswers;
        }

        // GET: api/McqAnswers/5
        [ResponseType(typeof(McqAnswer))]
        public async Task<IHttpActionResult> GetMcqAnswer(Guid id)
        {
            McqAnswer mcqAnswer = await db.McqAnswers.FindAsync(id);
            if (mcqAnswer == null)
            {
                return NotFound();
            }

            return Ok(mcqAnswer);
        }

        // PUT: api/McqAnswers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMcqAnswer(Guid id, McqAnswer mcqAnswer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mcqAnswer.McqAnswerId)
            {
                return BadRequest();
            }

            db.Entry(mcqAnswer).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!McqAnswerExists(id))
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

        // POST: api/McqAnswers
        [ResponseType(typeof(McqAnswer))]
        public async Task<IHttpActionResult> PostMcqAnswer(McqAnswer mcqAnswer)
        {
            mcqAnswer.McqAnswerId = Guid.NewGuid();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.McqAnswers.Add(mcqAnswer);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (McqAnswerExists(mcqAnswer.McqAnswerId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mcqAnswer.McqAnswerId }, mcqAnswer);
        }

        // DELETE: api/McqAnswers/5
        [ResponseType(typeof(McqAnswer))]
        public async Task<IHttpActionResult> DeleteMcqAnswer(Guid id)
        {
            McqAnswer mcqAnswer = await db.McqAnswers.FindAsync(id);
            if (mcqAnswer == null)
            {
                return NotFound();
            }

            db.McqAnswers.Remove(mcqAnswer);
            await db.SaveChangesAsync();

            return Ok(mcqAnswer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool McqAnswerExists(Guid id)
        {
            return db.McqAnswers.Count(e => e.McqAnswerId == id) > 0;
        }
    }
}