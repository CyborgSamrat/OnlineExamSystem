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
    public class McqQuestionsController : ApiController
    {
        private ExamDbContext db = new ExamDbContext();

        // GET: api/McqQuestions
        public IQueryable<McqQuestion> GetMcqQuestions()
        {
            return db.McqQuestions;
        }

        // GET: api/McqQuestions/5
        [ResponseType(typeof(McqQuestion))]
        public async Task<IHttpActionResult> GetMcqQuestion(Guid id)
        {
            McqQuestion mcqQuestion = await db.McqQuestions.FindAsync(id);
            if (mcqQuestion == null)
            {
                return NotFound();
            }

            return Ok(mcqQuestion);
        }

        // PUT: api/McqQuestions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMcqQuestion(Guid id, McqQuestion mcqQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mcqQuestion.McqQuestionId)
            {
                return BadRequest();
            }

            db.Entry(mcqQuestion).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!McqQuestionExists(id))
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

        // POST: api/McqQuestions
        [ResponseType(typeof(McqQuestion))]
        public async Task<IHttpActionResult> PostMcqQuestion(McqQuestion mcqQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.McqQuestions.Add(mcqQuestion);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (McqQuestionExists(mcqQuestion.McqQuestionId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mcqQuestion.McqQuestionId }, mcqQuestion);
        }

        // DELETE: api/McqQuestions/5
        [ResponseType(typeof(McqQuestion))]
        public async Task<IHttpActionResult> DeleteMcqQuestion(Guid id)
        {
            McqQuestion mcqQuestion = await db.McqQuestions.FindAsync(id);
            if (mcqQuestion == null)
            {
                return NotFound();
            }

            db.McqQuestions.Remove(mcqQuestion);
            await db.SaveChangesAsync();

            return Ok(mcqQuestion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool McqQuestionExists(Guid id)
        {
            return db.McqQuestions.Count(e => e.McqQuestionId == id) > 0;
        }
    }
}