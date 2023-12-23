
using Microsoft.Azure.Cosmos;
using System.ComponentModel;
using todo.Models;
using toDoTasks.Services;
using Container = Microsoft.Azure.Cosmos.Container;

namespace Temp.Services
{
    public class TaskService : ITaskService
    {
        private readonly Container _container;

        public TaskService(CosmosClient cosmosClient, string databaseName, string containerName)
        {
            _container = cosmosClient.GetContainer(databaseName, containerName);
        }

        public async Task<TaskModel> Add(TaskModel task)
        {
            var item = await _container.CreateItemAsync <TaskModel>(task, new PartitionKey(task.Id));
            return item;
        }

        public async Task<List<TaskModel>> Get(string cosmosQuery)
        {
            var query = _container.GetItemQueryIterator<TaskModel>(new QueryDefinition(cosmosQuery));
            List<TaskModel> results = new List<TaskModel>();
            
            while(query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response);
            }
            return results;
        }


        public async Task Delete(string id, string partition)
        {
            await _container.DeleteItemAsync<TaskModel>(id, new PartitionKey(partition));
        }

        public async Task<TaskModel> Update(TaskModel task)
        {
            var item = await _container.UpsertItemAsync<TaskModel>(task, new PartitionKey(task.Id));
            return item;
        }
    }
}
