using Camunda.Worker;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sp.CarBooking.Api.TaskHandlers
{
    [HandlerTopics("book-car", LockDuration = 10_000)]
    [HandlerVariables("CARTYPE")]
    public class BookCarHandler : IExternalTaskHandler
    {
        public async Task<IExecutionResult> HandleAsync(ExternalTask externalTask, CancellationToken cancellationToken)
        {
            if (!externalTask.Variables.TryGetValue("CARTYPE", out var carTypeVariable))
            {
                return new BpmnErrorResult("BookingFailed", "Car type not provided");
            }

            var carType = carTypeVariable.Value;

            await Task.Delay(1000);

            return new CompleteResult
            {
                Variables = new Dictionary<string, Variable>
                {
                    ["CAR-MESSAGE"] = Variable.String($"Reserving car now: {carType}!")
                }
            };
           
        }
    }
}
