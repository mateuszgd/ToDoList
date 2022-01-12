using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.EFTodoRepository
{
    public interface ITodoRepository
    {
        IEnumerable<TodoModel> GetToDoList();
        TodoModel GetTask(int todoId);
        void Add(TodoModel todoModel);
        void Edit(int todoId, TodoModel todoModel);
        void Delete(int todoId);
    }
}
