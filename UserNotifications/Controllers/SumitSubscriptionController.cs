using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UserNotifications.Controllers
{
    public class SumitSubscriptionController : Controller
    {
        // GET: SumitSubscription
        public ActionResult Index()
        {
            return View();
        }

        // GET: SumitSubscription/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SumitSubscription/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SumitSubscription/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SumitSubscription/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SumitSubscription/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SumitSubscription/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SumitSubscription/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
