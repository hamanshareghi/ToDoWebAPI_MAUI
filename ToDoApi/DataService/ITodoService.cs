using ToDoApi.Models;

namespace ToDoApi.DataService
{
    public interface ITodoService
    {
        IEnumerable<ToDo> GetAll();
        ToDo GetById(int id);
        void Add(ToDo todo);
        void Update(int id,ToDo todo);
        void Delete(int id);
    }
}
