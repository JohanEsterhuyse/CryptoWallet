using System;
using System.Net;
using CryptoWallet.Notification.Common.Interface.Common;
using CryptoWallet.Orders.Domain.Model;
using Newtonsoft.Json;
using RestSharp;

namespace CryptoWallet.Orders.Service.Helper
{
    public class NotificationHelper : INotificationHelper
    {
        private readonly IAppSettings _appSettings;

        public NotificationHelper(IAppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public void SendNotificationMessage(NotificationMessage notificationMessage)
        {
            var client = new RestClient(_appSettings.NotificationApiBase);
            var request = new RestRequest("/resource/", Method.POST);

            // Json to post.
            string jsonToSend = JsonConvert.SerializeObject(notificationMessage);

            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            client.ExecuteAsync(request, response =>
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    // OK
                }
                else
                {
                    // NOK
                }
            });


        }
    }
}
