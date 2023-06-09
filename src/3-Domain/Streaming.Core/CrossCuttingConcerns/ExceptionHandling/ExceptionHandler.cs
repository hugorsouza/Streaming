using FluentValidation;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Streaming.Core.CrossCuttingConcerns.ExceptionHandling.Handlers;
using Streaming.Core.Utilities.ServiceResult;

namespace Streaming.Core.CrossCuttingConcerns.ExceptionHandling
{
    class ExceptionHandler
    {
        private readonly IDictionary<Type, IExceptionHandler> _handlers;

        public ExceptionHandler()
        {
            _handlers = new Dictionary<Type, IExceptionHandler>
            {
                { typeof(ValidationException), new ValidationExceptionHandler() },
            };
        }

        /// <summary>
        /// Handles exceptions on methods whose args.ReturnType is ServiceResult.
        /// <para>If there is no handler to handle the exception, the program continues its default flow.</para>
        /// </summary>
        /// <param name="args"></param>
        public void Handle(MethodExecutionArgs args)
        {
            var returnType = ((MethodInfo)args.Method).ReturnType;
            if (!returnType.IsAssignableTo(typeof(ServiceResult))) return;

            var type = args.Exception.GetType();
            if (_handlers.ContainsKey(type)) _handlers[type].Execute(args);
            else args.FlowBehavior = FlowBehavior.Default;
        }
    }
}
