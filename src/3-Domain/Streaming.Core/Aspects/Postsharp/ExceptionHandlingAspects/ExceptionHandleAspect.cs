using PostSharp.Aspects;
using PostSharp.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Streaming.Core.CrossCuttingConcerns.ExceptionHandling;

namespace Streaming.Core.Aspects.Postsharp.ExceptionHandlingAspects
{
    [PSerializable]
    public sealed class ExceptionHandleAspect : OnExceptionAspect
    {
        public override void OnException(MethodExecutionArgs args)
        {
            var exceptionHandler = new ExceptionHandler();
            exceptionHandler.Handle(args);
        }
    }
}
