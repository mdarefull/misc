using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;

namespace KnowledgeMap.Application.Mvc.DiExternalModule.InterceptionBehaviors
{
    internal sealed class RepositoryLoggingBehavior : IInterceptionBehavior
    {
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            // try/catch don't work here...
            var result = getNext()(input, getNext);

            if (result.Exception is DbEntityValidationException)
            {
                var e = (DbEntityValidationException)result.Exception;
                Debug.Fail(string.Format("Exception while Commiting Changes to Db at {0}", DateTime.Now));
                var errors = e.EntityValidationErrors
                                .SelectMany(er => er.ValidationErrors);
                foreach (var error in errors)
                    Debug.Fail(error.PropertyName, error.ErrorMessage);
                Debugger.Break();
            }

            return result;
        }

        public bool WillExecute
        {
            get { return true; }
        }
    }
}