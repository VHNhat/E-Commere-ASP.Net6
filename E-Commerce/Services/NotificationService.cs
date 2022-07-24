using E_Commerce.DataAccess;
using E_Commerce.Generic;
using E_Commerce.Models;

namespace E_Commerce.Services
{
    public class NotificationService : GenericService<Notification>
    {
        private readonly IConfiguration _config;
        private readonly string sqlDataSource;
        private readonly Context ctx;

        public NotificationService(IConfiguration config, Context context) : base(config, context)
        {
            _config = config;
            sqlDataSource = _config.GetConnectionString("mysql");
            ctx = context;
        }

        public int UpdateById(long id, Notification notification)
        {
            try
            {
                Notification noti = ctx.Notifications.Single(s => s.Id == id);

                noti.Title = notification.Title;
                noti.Content = notification.Content;
                noti.Status = notification.Status;
                noti.ReadAt = notification.ReadAt;
                noti.LastModifiedAt = DateTime.Now;
                
                return ctx.SaveChanges();

            }
            catch
            {
                return -1;
            }
        }
    }
}
