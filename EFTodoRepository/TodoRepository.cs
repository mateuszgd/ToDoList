using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.DbConnect;
using ToDoList.Models;

namespace ToDoList.EFTodoRepository
{
    public class TodoRepository : ITodoRepository
    {
        private EFDbContext dbContext;

        public TodoRepository(EFDbContext context)
        {
            dbContext = context;
        }

        public IEnumerable<TodoModel> GetToDoList()
        {
            var result = dbContext.Todos.Where(x => x.Done == false);

            return result;
        }

        public TodoModel GetTask(int todoId)
        {
            var result = dbContext.Todos.FirstOrDefault(x => x.TodoId == todoId);

            return result;
        }

        public void Add(TodoModel todoModel)
        {
            dbContext.Todos.Add(todoModel);
            dbContext.SaveChanges();
        }

        public void Delete(int todoId)
        {
            var result = dbContext.Todos.FirstOrDefault(x => x.TodoId == todoId);

            dbContext.Todos.Remove(result);
            dbContext.SaveChanges();
        }

        public void Edit(int todoId, TodoModel todoModel)
        {
            var result = dbContext.Todos.FirstOrDefault(x => x.TodoId == todoId);

            result.Name = todoModel.Name;
            result.Description = todoModel.Description;
            result.Done = todoModel.Done;
            result.Hide = todoModel.Hide;

            dbContext.SaveChanges();
        }
    }
}
