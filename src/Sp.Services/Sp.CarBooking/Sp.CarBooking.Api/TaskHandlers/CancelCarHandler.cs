using Camunda.Worker;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sp.CarBooking.Api.TaskHandlers
{
    [HandlerTopics("cancel-car", LockDuration = 10_000)]
    public class CancelCarHandler : IExternalTaskHandler
    {
        public async Task<IExecutionResult> HandleAsync(ExternalTask externalTask, CancellationToken cancellationToken)
        {
            Console.WriteLine();
            Console.WriteLine("Cancelling car now...");
            Console.WriteLine();

            var result = new CompleteResult();

            result.Variables = new Dictionary<string, Variable>
            {
                ["CANCEL-CAR-MESSAGE"] = Variable.String($"Cancelling car now.")
            };

            return result;
        }
    }
}
