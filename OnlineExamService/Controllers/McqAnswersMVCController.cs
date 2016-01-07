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
    public class McqAnswersMVCController : Controller
    {
        private ExamDbContext db = new ExamDbContext();

        // GET: McqAnswersMVC
        public async Task<ActionResult> Index()
        {
            return View(await db.McqAnswers.ToListAsync());
        }

        // GET: McqAnswersMVC/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            McqAnswer mcqAnswer = await db.McqAnswers.FindAsync(id);
            if (mcqAnswer == null)
            {
                return HttpNotFound();
            }
            return View(mcqAnswer);
        }

        // GET: McqAnswersMVC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: McqAnswersMVC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "McqAnswerId,McqAnswers")] McqAnswer mcqAnswer)
        {
            McqExam exam = db.McqExams.Find(new Guid("6b9660d8-6a0b-4c02-9daf-fd4bb25b0ebb"));
            mcqAnswer.Exam = exam;
            if (ModelState.IsValid)
            {
                mcqAnswer.McqAnswerId = Guid.NewGuid();
                db.McqAnswers.Add(mcqAnswer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(mcqAnswer);
        }

        // GET: McqAnswersMVC/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            McqAnswer mcqAnswer = await db.McqAnswers.FindAsync(id);
            if (mcqAnswer == null)
            {
                return HttpNotFound();
            }
            return View(mcqAnswer);
        }

        // POST: McqAnswersMVC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "McqAnswerId,McqAnswers")] McqAnswer mcqAnswer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mcqAnswer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mcqAnswer);
        }

        // GET: McqAnswersMVC/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            McqAnswer mcqAnswer = await db.McqAnswers.FindAsync(id);
            if (mcqAnswer == null)
            {
                return HttpNotFound();
            }
            return View(mcqAnswer);
        }

        // POST: McqAnswersMVC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            McqAnswer mcqAnswer = await db.McqAnswers.FindAsync(id);
            db.McqAnswers.Remove(mcqAnswer);
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
