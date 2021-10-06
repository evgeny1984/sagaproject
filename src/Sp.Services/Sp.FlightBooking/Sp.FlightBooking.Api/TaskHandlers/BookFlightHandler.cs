using Camunda.Worker;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sp.FlightBooking.Api.TaskHandlers
{
    [HandlerTopics("book-flight", LockDuration = 10_000)]
    public class BookFlightHandler : IExternalTaskHandler
    {
        public Task<IExecutionResult> HandleAsync(ExternalTask externalTask, CancellationToken cancellationToken)
        {
            Console.WriteLine();
            Console.WriteLine("Reserving flight now...");
            Console.WriteLine();

            var result = Task.FromResult<IExecutionResult>(new BpmnErrorResult("BookingFailed", "The flight cannot be booked!"));

            return result;
        }
    }
}
