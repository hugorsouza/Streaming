using System.Collections.Generic;
using Streaming.Core.Entities;

namespace Streaming.Entities.Concrete
{
    public class Category : IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public ICollection<Movies> Movies { get; set; }
        public ICollection<Series> Series { get; set; }
    }

}
