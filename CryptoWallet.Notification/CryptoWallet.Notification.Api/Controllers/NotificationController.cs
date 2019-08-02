using CryptoWallet.Notification.Service;
using CryptoWallet.Service.Notification;
using Microsoft.AspNetCore.Mvc;

namespace CryptoWallet.Controllers
{
    [Route("api/Notifications")]
    public class NotificationController : Controller
    {
        private readonly NotificationsService notificationsService;

        public NotificationController(NotificationsService notificationsService)
        {
            this.notificationsService = notificationsService;
        }

        [HttpPost]
        [Route("SendNotification")]
        public void SendNotification([FromBody]NotificationMessageDto notificationMessageDto)
        {
            notificationsService.SendNotification(notificationMessageDto);
        }
    }
}
