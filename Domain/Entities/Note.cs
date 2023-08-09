using Domain.Entities.Base;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Note : BaseEntity
    {
        public string Message { get; set; }
        public string Title { get; set; }
        [JsonIgnore]
        public Person Person { get; set; }
        public Note() { }
    }
}
