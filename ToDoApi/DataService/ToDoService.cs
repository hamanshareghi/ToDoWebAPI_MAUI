using System.Diagnostics;
using ToDoApi.Data;
using ToDoApi.Models;

namespace ToDoApi.DataService
{
    public class ToDoService : ITodoService
    {
        private AppDbContext _context;

        public ToDoService(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<ToDo> GetAll()
        {
            var data = _context.ToDo
                .ToList();
            return data;
        }

        public ToDo GetById(int id)
        {
            var data = _context.ToDo
                .FirstOrDefault(s => s.Id == id);
            if(data == null)
                Debug.WriteLine("-- Not Found --");
            return data;

        }

        public void Add(ToDo todo)
        {
            _context.ToDo.Add(todo);
            _context.SaveChanges();

        }

        public void Update(ToDo todo)
        {
            _context.ToDo.Update(todo);
            _context.SaveChanges();

        }

        public void Delete(int id)
        {
            var data = _context.ToDo
                .FirstOrDefault(s => s.Id == id);
            if (data == null)
                Debug.WriteLine("-- Not Found --");
            _context.ToDo.Remove(data);
            _context.SaveChanges();
        }
    }
}
