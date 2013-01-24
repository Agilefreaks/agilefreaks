using System.Linq;

namespace AgileFreaks.Controllers
{
    public partial class AgileFreaksController
    {
        public IQueryable<Models.TodoItem> GetTodoItems()
        {
            return DbContext.TodoItems.OrderBy(t => t.TodoItemId);
        }

        public void InsertTodoItem(Models.TodoItem entity)
        {
            InsertEntity(entity);
        }

        public void UpdateTodoItem(Models.TodoItem entity)
        {
            UpdateEntity(entity);
        }

        public void DeleteTodoItem(Models.TodoItem entity)
        {
            DeleteEntity(entity);
        }
    }
}
