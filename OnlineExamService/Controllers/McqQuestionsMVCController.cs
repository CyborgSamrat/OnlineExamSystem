using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineExamService.DbContexts;
using OnlineExamService.Models;

namespace OnlineExamService.Controllers
{
    public class McqQuestionsMVCController : Controller
    {
        private ExamDbContext db = new ExamDbContext();

        // GET: McqQuestionsMVC
        public async Task<ActionResult> Index()
        {
            return View(await db.McqQuestions.ToListAsync());
        }

        // GET: McqQuestionsMVC/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            McqQuestion mcqQuestion = await db.McqQuestions.FindAsync(id);
            if (mcqQuestion == null)
            {
                return HttpNotFound();
            }
            return View(mcqQuestion);
        }

        // GET: McqQuestionsMVC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: McqQuestionsMVC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "McqQuestionId,QuestionText,OptionA,OptionB,OptionC,OptionD,CorrectAnswer,SubjectCode,DifficultyLevel,Class,Type")] McqQuestion mcqQuestion)
        {
            if (ModelState.IsValid)
            {
                mcqQuestion.McqQuestionId = Guid.NewGuid();
                db.McqQuestions.Add(mcqQuestion);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(mcqQuestion);
        }

        // GET: McqQuestionsMVC/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            McqQuestion mcqQuestion = await db.McqQuestions.FindAsync(id);
            if (mcqQuestion == null)
            {
                return HttpNotFound();
            }
            return View(mcqQuestion);
        }

        // POST: McqQuestionsMVC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "McqQuestionId,QuestionText,OptionA,OptionB,OptionC,OptionD,CorrectAnswer,SubjectCode,DifficultyLevel,Class,Type")] McqQuestion mcqQuestion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mcqQuestion).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mcqQuestion);
        }

        // GET: McqQuestionsMVC/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            McqQuestion mcqQuestion = await db.McqQuestions.FindAsync(id);
            if (mcqQuestion == null)
            {
                return HttpNotFound();
            }
            return View(mcqQuestion);
        }

        // POST: McqQuestionsMVC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            McqQuestion mcqQuestion = await db.McqQuestions.FindAsync(id);
            db.McqQuestions.Remove(mcqQuestion);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
