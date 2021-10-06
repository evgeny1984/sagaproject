using Camunda.Worker;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sp.FlightBooking.Api.TaskHandlers
{
    [HandlerTopics("cancel-flight", LockDuration = 10_000)]
    public class CancelFlightHandler : IExternalTaskHandler
    {
        public async Task<IExecutionResult> HandleAsync(ExternalTask externalTask, CancellationToken cancellationToken)
        {
            Console.WriteLine();
            Console.WriteLine("Cancelling flight now...");
            Console.WriteLine();

            await Task.Delay(1000);

            var result = new CompleteResult();

            result.Variables = new Dictionary<string, Variable>
            {
                ["CANCEL-FLIGHT-MESSAGE"] = Variable.String($"Cancelling flight now.")
            };

            return result;
        }
    }
}
