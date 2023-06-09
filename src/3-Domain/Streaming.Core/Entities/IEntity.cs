using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streaming.Core.Entities
{
    public interface IEntity
    {
    }

    /// <typeparam name="TKey">The type used for the primary key.</typeparam>
    public interface IEntity<TKey> : IEntity where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; }
    }
}
