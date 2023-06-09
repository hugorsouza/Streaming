using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streaming.Core.CrossCuttingConcerns.ExceptionHandling.Handlers
{
    interface IExceptionHandler
    {
        void Execute(MethodExecutionArgs args);
    }
}
