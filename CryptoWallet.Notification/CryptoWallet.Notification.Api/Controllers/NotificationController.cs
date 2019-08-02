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
        public void Post([FromBody]NotificationMessageDto notificationMessageDto)
        {
            notificationsService.SendNotification(notificationMessageDto);
        }
    }
}
