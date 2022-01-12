using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.EFTodoRepository;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class TodoController : Controller
    {
        private ITodoRepository todoRepository;

        public TodoController(ITodoRepository repository)
        {
            todoRepository = repository;
        }

        public ActionResult Index()
        {
            return View(todoRepository.GetToDoList());
        }

        public ActionResult Details(int id)
        {
            return View(todoRepository.GetTask(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TodoModel todoModel)
        {
            todoRepository.Add(todoModel);

            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int id)
        {
            return View(todoRepository.GetTask(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TodoModel todoModel)
        {
            todoRepository.Edit(id, todoModel);

            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(int id)
        {
            return View(todoRepository.GetTask(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TodoModel todoModel)
        {
            todoRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        public ActionResult Done(int id)
        {
            var result = todoRepository.GetTask(id);
            
            result.Done = true;

            todoRepository.Edit(id, result);

            return RedirectToAction(nameof(Index));
        }

        public ActionResult Hide(int id)
        {
            var result = todoRepository.GetTask(id);

            if (result.Hide == true)
            {
                result.Hide = false;
            }
            else
            {
                result.Hide = true;
            }

            todoRepository.Edit(id, result);

            return RedirectToAction(nameof(Index));
        }
    }
}
