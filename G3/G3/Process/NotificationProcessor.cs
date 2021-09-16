using G3.DAL;
using G3.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G3.Process
{
    public interface INotificationProcessor
    {
        public void notify(int vehicleId);
    }
    public class NotificationProcessor : INotificationProcessor
    {
        private readonly Context _context;

        public NotificationProcessor(Context context)
        {
            _context = context;
        }

        public void notify(int vehicleId)
        {
            foreach(UserVehicleWatch watchedvehicle in _context.UserVehicleWatches)
            {
                if (watchedvehicle.VehicleId == vehicleId && watchedvehicle.Active == true)
                {
                    Notification notification = new Notification();
                    notification.Body = $"Tracked vehicle {watchedvehicle.Vehicle.Price.ToString("0.00")}’s price has been updated!";
                    _context.Notifications.Add(notification);
                    _context.SaveChanges();
                }
            }
        }
    }
}
