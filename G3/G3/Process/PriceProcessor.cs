using G3.DAL;
using G3.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G3.Process
{
    public interface IPriceProcessor
    {
        public string PriceUpdate(int userid, int vehicleid, int newprice);
        
    }
    public class PriceProcessor : IPriceProcessor
    {
        private readonly Context _context;
        private readonly INotificationProcessor _notification;

        public PriceProcessor(Context context, INotificationProcessor notificationProcessor)
        {
            _context = context;
            _notification = notificationProcessor;
        }

        public string PriceUpdate(int userId, int vehicleId, int newPrice)
        {
            string response;
            User user = (User)(from u in _context.Users where u.UserId.Equals(userId) select u);
            if (user != null)
            {
                Vehicle vehicle = (Vehicle)(from v in _context.Vehicles where v.VehicleId.Equals(vehicleId) select v);

                if (vehicle != null)
                {
                    if (newPrice > 0 && (newPrice % 25 == 0))
                    {
                        Vehicle v = _context.Vehicles.First(i => i.VehicleId == vehicleId);
                        v.Price = newPrice;
                        _context.SaveChanges();
                        _notification.notify(v.VehicleId);
                        response = "Price sucessfully updated.";
                    }
                    else
                    {
                        response = "price must be positive and a multiple of 25.";
                    }
                }
                else
                {
                    response = "Vehicle id not found in our databases.";
                }
            }
            else
            {
                response = "User not found in our database.";
            }
            return response;
        }
    }

}

