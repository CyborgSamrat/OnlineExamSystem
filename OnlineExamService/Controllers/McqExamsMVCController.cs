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
    public class McqExamsMVCController : Controller
    {
        private ExamDbContext db = new ExamDbContext();

        // GET: McqExamsMVC
        public async Task<ActionResult> Index()
        {
            return View(await db.McqExams.ToListAsync());
        }

        // GET: McqExamsMVC/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            McqExam mcqExam = await db.McqExams.FindAsync(id);
            if (mcqExam == null)
            {
                return HttpNotFound();
            }
            return View(mcqExam);
        }

        // GET: McqExamsMVC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: McqExamsMVC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "McqExamId,NumberOfMcqQuestion,Title,Type,CourseName,FullMarks,ExamTime,AllocatedTimeInMinute,DifficultyLevel")] McqExam mcqExam)
        {
            if (ModelState.IsValid)
            {
                mcqExam.McqExamId = Guid.NewGuid();
                db.McqExams.Add(mcqExam);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(mcqExam);
        }

        // GET: McqExamsMVC/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            McqExam mcqExam = await db.McqExams.FindAsync(id);
            

            if (mcqExam == null)
            {
                return HttpNotFound();
            }
            return View(mcqExam);
        }

        // POST: McqExamsMVC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "McqExamId,NumberOfMcqQuestion,Title,Type,CourseName,FullMarks,ExamTime,AllocatedTimeInMinute,DifficultyLevel")] McqExam mcqExam)
        {
            List<string> Answers = new List<string>();
            Answers.Add("A");
            Answers.Add("B");
            Answers.Add("C");
            mcqExam.McqAnswers = Answers;
            if (ModelState.IsValid)
            {
                db.Entry(mcqExam).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mcqExam);
        }

        // GET: McqExamsMVC/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            McqExam mcqExam = await db.McqExams.FindAsync(id);
            if (mcqExam == null)
            {
                return HttpNotFound();
            }
            return View(mcqExam);
        }

        // POST: McqExamsMVC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            McqExam mcqExam = await db.McqExams.FindAsync(id);
            db.McqExams.Remove(mcqExam);
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
