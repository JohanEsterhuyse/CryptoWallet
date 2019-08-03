using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;
using CryptoWallet.Notification.Lambda.Model;
using CryptoWallet.Service.Notification;
using CryptoWallet.Notification.Lambda.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using CryptoWallet.Notification.Service;


// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace CryptoWallet.Notification.Lambda
{
    public class Function
    {
        /// <summary>
        /// Default constructor. This constructor is used by Lambda to construct the instance. When invoked in a Lambda environment
        /// the AWS credentials will come from the IAM role associated with the function and the AWS region will be set to the
        /// region the Lambda function is executed in.
        /// </summary>
        public Function()
        {

        }


        /// <summary>
        /// This method is called for every Lambda invocation. This method takes in an SQS event object and can be used 
        /// to respond to SQS messages.
        /// </summary>
        /// <param name="evnt"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task FunctionHandler(SQSEvent evnt, ILambdaContext context)
        {
            using (var serviceProvider = DependencyInjectionHelper.ConfigureServices())
            {
                foreach (var message in evnt.Records)
                {
                    await ProcessMessageAsync(message, serviceProvider);
                }
            }
        }

        private async Task ProcessMessageAsync(SQSEvent.SQSMessage message, ServiceProvider serviceProvider)
        {
            var sqsMessage = JsonConvert.DeserializeObject<SqsMessage>(message.Body);
            var notification = JsonConvert.DeserializeObject<NotificationMessageDto>(sqsMessage.Message);

            var notificationsService = serviceProvider.GetService<NotificationsService>();
            notificationsService.SendNotification(notification);

            await Task.CompletedTask;
        }
    }
}
