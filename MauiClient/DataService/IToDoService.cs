using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAUIClient.Models;


namespace MAUIClient.DataService
{
    public interface IToDoService
    {
        Task<List<ToDo>> GetAllAsync();
        Task AddToDoAsync(ToDo todo);
        Task DeleteToDoAsync(int id);
        Task UpdateToDoAsync(ToDo todo);
    }
}
