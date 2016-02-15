using System;
using System.ComponentModel;

namespace BookReader.Model
{
    public class BaseModel
    {
        private readonly BackgroundWorker _worker = new BackgroundWorker();
        protected void RunAsync<TPredicateReturnType>(Func<TPredicateReturnType> predicateFunction,
            Action predicateSuccesAction,
            Action<TPredicateReturnType> predicateFailedAction,
            Action<Exception> exceptionAction) where TPredicateReturnType : IPredicateResult
        {
            _worker.DoWork += (sender, args) => predicateFunction();
            _worker.RunWorkerCompleted += (sender, args) =>
            {
                if (args.Error != null)
                {
                    exceptionAction(args.Error);
                    return;
                }
                if (args.Result != null && ((TPredicateReturnType) args.Result).Succes)
                {
                    predicateSuccesAction();
                }
                else
                {
                    predicateFailedAction((TPredicateReturnType) args.Result);
                }
            };
        }
    }
}