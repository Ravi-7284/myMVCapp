using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using mymvcapp.Models;

namespace YourNamespace.Controllers
{
    public class TodoController : Controller
    {
        // In-memory list to store tasks
        private static List<TaskItem> _tasks = new List<TaskItem>();
        private static int _nextId = 1;

        // Action to display the list of tasks
        public IActionResult Index()
        {
            return View(_tasks);
        }

        // Action to display the form for adding a new task
        public IActionResult Create()
        {
            return View();
        }

        // Action to handle the form submission for adding a new task
        [HttpPost]
        public IActionResult Create(TaskItem task)
        {
            if (ModelState.IsValid)
            {
                task.Id = _nextId++;
                _tasks.Add(task);
                return RedirectToAction("Index");
            }
            return View(task);
        }

        // Action to mark a task as completed
        public IActionResult ToggleComplete(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                task.IsCompleted = !task.IsCompleted;
            }
            return RedirectToAction("Index");
        }

        // Action to delete a task
        public IActionResult Delete(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                _tasks.Remove(task);
            }
            return RedirectToAction("Index");
        }
    }
}