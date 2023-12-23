
using todo.Models;

namespace toDoTasks.Services
{
    public interface ITaskService
    {
        Task<List<TaskModel>> Get(string cosmosQuery);
        Task<TaskModel> Add(TaskModel task);
        Task<TaskModel> Update(TaskModel task);

        Task Delete(string id, string partition);

    }
}
