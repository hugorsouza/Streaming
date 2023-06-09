using Streaming.Core.Entities;

namespace Streaming.Entities.Concrete
{
    public class Series : IEntity<int>
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Actor { get; set; }
        public string Director { get; set; }
        public string Serie { get; set; }
        public int Seasons { get; set; }

        public string Streamings { get; set; }
        public Category Category { get; set; }
    }
}
