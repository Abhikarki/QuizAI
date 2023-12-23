using Newtonsoft.Json;

namespace todo.Models
{
    public class TaskModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")] 
        public string Description { get; set; }
    }
}
