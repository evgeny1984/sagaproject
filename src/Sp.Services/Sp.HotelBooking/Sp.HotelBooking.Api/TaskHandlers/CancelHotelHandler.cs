using Camunda.Worker;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sp.HotelBooking.Api.TaskHandlers
{
    [HandlerTopics("cancel-hotel", LockDuration = 10_000)]
    public class CancelHotelHandler : IExternalTaskHandler
    {
        public async Task<IExecutionResult> HandleAsync(ExternalTask externalTask, CancellationToken cancellationToken)
        {
            Console.WriteLine();
            Console.WriteLine("Cancelling hotel now...");
            Console.WriteLine();

            var result = new CompleteResult();

            result.Variables = new Dictionary<string, Variable>
            {
                ["CANCEL-HOTEL-MESSAGE"] = Variable.String($"Cancelling hotel now.")
            };

            return result;
        }
    }
}
