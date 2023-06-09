using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streaming.Core.Utilities.CustomExceptions
{
    [Serializable]
    public class InvalidGenericTypeException : Exception
    {
        public InvalidGenericTypeException(Type invalidType) : base($"{invalidType.FullName} is not the expected generic type.") { }

        public InvalidGenericTypeException(string message) : base(message) { }
    }
}
