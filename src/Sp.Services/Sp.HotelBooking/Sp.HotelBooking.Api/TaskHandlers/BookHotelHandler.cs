using Camunda.Worker;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sp.HotelBooking.Api.TaskHandlers
{
    [HandlerTopics("book-hotel", LockDuration = 10_000)]
    public class BookHotelHandler : IExternalTaskHandler
    {
        public async Task<IExecutionResult> HandleAsync(ExternalTask externalTask, CancellationToken cancellationToken)
        {
            Console.WriteLine();
            Console.WriteLine("Book hotel now...");
            Console.WriteLine();

            await Task.Delay(1000);

            var result = new CompleteResult();

            result.Variables = new Dictionary<string, Variable>
            {
                ["HOTEL-MESSAGE"] = Variable.String($"Reserving hotel now!")
            };

            return result;
        }
    }
}
