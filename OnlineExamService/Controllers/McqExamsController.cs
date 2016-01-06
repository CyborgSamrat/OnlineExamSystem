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

namespace OnlineExamService.Controllers
{
    public class McqExamsController : ApiController
    {
        private ExamDbContext db = new ExamDbContext();

        // GET: api/McqExams
        public IQueryable<McqExam> GetMcqExams()
        {
            return db.McqExams;
        }

        // GET: api/McqExams/5
        [ResponseType(typeof(McqExam))]
        public async Task<IHttpActionResult> GetMcqExam(Guid id)
        {
            McqExam mcqExam = await db.McqExams.FindAsync(id);
            if (mcqExam == null)
            {
                return NotFound();
            }

            return Ok(mcqExam);
        }

        // PUT: api/McqExams/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMcqExam(Guid id, McqExam mcqExam)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mcqExam.McqExamId)
            {
                return BadRequest();
            }

            db.Entry(mcqExam).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!McqExamExists(id))
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

        // POST: api/McqExams
        [ResponseType(typeof(McqExam))]
        public async Task<IHttpActionResult> PostMcqExam(McqExam mcqExam)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            mcqExam.McqExamId = Guid.NewGuid();
            Random rnd = new Random();

            List<McqQuestion> mcqQuestions = db.McqQuestions.ToList();
            List<McqQuestion> questions = new List<McqQuestion>();

            for (int i = 0; i < mcqExam.NumberOfMcqQuestion; i++)
            {
                int r = rnd.Next(mcqQuestions.Count);
                questions.Add(mcqQuestions[r]);
                mcqQuestions.RemoveAt(r);
            }
            mcqExam.McqQuestions = questions;
            db.McqExams.Add(mcqExam);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (McqExamExists(mcqExam.McqExamId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mcqExam.McqExamId }, mcqExam);
        }

        // DELETE: api/McqExams/5
        [ResponseType(typeof(McqExam))]
        public async Task<IHttpActionResult> DeleteMcqExam(Guid id)
        {
            McqExam mcqExam = await db.McqExams.FindAsync(id);
            if (mcqExam == null)
            {
                return NotFound();
            }

            db.McqExams.Remove(mcqExam);
            await db.SaveChangesAsync();

            return Ok(mcqExam);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool McqExamExists(Guid id)
        {
            return db.McqExams.Count(e => e.McqExamId == id) > 0;
        }
    }
}