using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MAUIClient.DataService;
using MAUIClient.Models;


namespace MAUIClient.DataService
{
    public class ToDoService : IToDoService
    {
        private  readonly HttpClient _httpClient;
        private readonly string _baseAddress;
        private readonly string _url;
        private readonly JsonSerializerOptions _jsoSerializerOption;

        public ToDoService(HttpClient httpClient)
        {
            //_httpClient = new HttpClient();
            _httpClient=httpClient;
            _baseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5009" : "http://localhost:5009";
            _url = $"{_baseAddress}/api";
            _jsoSerializerOption = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

        }


        public async Task AddToDoAsync(ToDo todo)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine(" -- No Internet Access -- ");
                return ;
            }

            try
            {
                string jsonToDo = JsonSerializer.Serialize<ToDo>(todo, _jsoSerializerOption);
                StringContent content = new StringContent(jsonToDo, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync($"{_url}/todo", content);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(" SuccessFull Create ");
                }
                else
                {
                    Debug.WriteLine(" -- No Http 2xx response -- ");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($" Whoops Exception : {ex} ");
            }

            return;
        }

        public async Task DeleteToDoAsync(int id)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine(" ----- No internet Access ---- ");
                return; 
            }


            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync($"{_url}/todo/{id}");
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(" SuccessFull Create ");
                }
                else
                {
                    Debug.WriteLine(" -- No Http 2xx response -- ");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($" Whoops Exception : {ex} ");
            }
            return;
            
        }

        public async Task<List<ToDo>> GetAllAsync()
        {
            List<ToDo> todos = new List<ToDo>();
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine(" -- No Internet Access -- ");
                return todos;
            }

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/todo");
                if (response.IsSuccessStatusCode)
                {
                    string context = await response.Content.ReadAsStringAsync();
                    todos = JsonSerializer.Deserialize<List<ToDo>>(context, _jsoSerializerOption);
                }
                else
                {
                   
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($" Whoops Exception : {ex} ");
            }

            return todos;
        }

        public async  Task UpdateToDoAsync(ToDo todo)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine(" -- No Internet Access -- ");
                return;
            }

            try
            {
                string jsonToDo = JsonSerializer.Serialize<ToDo>(todo, _jsoSerializerOption);
                StringContent content = new StringContent(jsonToDo, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PutAsync($"{_url}/todo/{todo.Id}", content);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(" SuccessFull Create ");
                }
                else
                {
                    Debug.WriteLine(" -- No Http 2xx response -- ");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($" Whoops Exception : {ex} ");
            }

            return;
        }
    }
}
