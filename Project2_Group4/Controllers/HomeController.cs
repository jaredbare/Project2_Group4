using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project2_Group4.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Project2_Group4.Controllers
{
    public class HomeController : Controller
    {
        private TaskDatabaseContext _TaskContext { get; set; }
        public HomeController(TaskDatabaseContext x)
        {
            _TaskContext = x;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        public IActionResult Quad()
        {

            var tasks = _TaskContext.Tasks.Include(x => x.Category).ToList();
            return View(tasks);
        }
        [HttpGet]
        public IActionResult TaskForm()
        {
            ViewBag.Categories = _TaskContext.Categories.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult TaskForm(TaskModel tm)
        {
            if (ModelState.IsValid)
            {
                _TaskContext.Add(tm);
                _TaskContext.SaveChanges();
                return View("Confirmation", tm);
            }
            else
            {
                ViewBag.Tasks = _TaskContext.Tasks.ToList();
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int taskid)
        {
            ViewBag.Categories = _TaskContext.Categories.ToList();
            var form = _TaskContext.Tasks.Single(x => x.TaskID == taskid);
            return View("TaskForm", form);
        }
        [HttpPost]
        public IActionResult Edit(TaskModel response)
        {
            _TaskContext.Update(response);
            _TaskContext.SaveChanges();
            return RedirectToAction("Quad");
        }
        [HttpGet]
        public IActionResult Delete(int taskid)
        {
            var form = _TaskContext.Tasks.Single(x => x.TaskID == taskid);
            //ViewBag.Categories = daContext.Categories.ToList();
            return View(form);
        }
        [HttpPost]
        public IActionResult Delete(TaskModel tm)
        {
            _TaskContext.Tasks.Remove(tm);
            _TaskContext.SaveChanges();
            return RedirectToAction("Quad");
        }
    }
}
