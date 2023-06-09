using Streaming.Core.Entities;

namespace Streaming.Entities.Concrete
{
    public class Movies : IEntity<int>
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Actor { get; set; }
        public string Director { get; set; }
        public string Movie { get; set; }
        public int RunningTime { get; set; }
        public Category Category { get; set; }
    }
}
