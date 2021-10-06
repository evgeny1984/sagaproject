using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp.CarBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CamundaController : Controller
    {
        // GET: CamundaController
        public ActionResult Index()
        {
            return Ok("test");
        }

        // GET: CamundaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CamundaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CamundaController/Create
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

        // GET: CamundaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CamundaController/Edit/5
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

        // GET: CamundaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CamundaController/Delete/5
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
