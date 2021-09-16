using G3.DAL;
using G3.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G3.Process
{
    public interface IWatchVehicleProcessor
    {
        UserVehicleWatch TriggerWatchVehicle(int vehicleId, int userId);
        IEnumerable<UserVehicleWatch> GetActiveTrackedByUser(int userId);
    }

    public class WatchVehicleProcessor : IWatchVehicleProcessor
    {
        private readonly Context _context;

        public WatchVehicleProcessor(Context context)
        {
            _context = context;
        }

        public IEnumerable<UserVehicleWatch> GetActiveTrackedByUser(int userId)
        {
            List<UserVehicleWatch> watchedVehicles = (List<UserVehicleWatch>)(from UWV in _context.UserVehicleWatches
                                                                              where UWV.UserId.Equals(userId)
                                                                              where UWV.Active.Equals(true)
                                                                              select UWV);
            return watchedVehicles;
        }

        public UserVehicleWatch TriggerWatchVehicle(int vehicleId, int userId)
        {
            UserVehicleWatch userWatchVehicle = (UserVehicleWatch)(from UWV in _context.UserVehicleWatches
                                                                   where UWV.User.Equals(userId)
                                                                   where UWV.VehicleId.Equals(vehicleId) 
                                                                   select UWV);
            if (userWatchVehicle != null)
            {
                _context.UserVehicleWatches.Remove(userWatchVehicle);
                userWatchVehicle = (UserVehicleWatch)(from UWV in _context.UserVehicleWatches
                                                      where UWV.WatchId.Equals(userWatchVehicle.WatchId)
                                                      select UWV);
                return userWatchVehicle;
            }
            else
            {
                Vehicle vehicle = (Vehicle)(from v in _context.Vehicles 
                                            where v.VehicleId.Equals(vehicleId) 
                                            select v);
                User user = (User)(from u in _context.Users
                                   where u.UserId.Equals(userId) 
                                   select u);
                userWatchVehicle = new UserVehicleWatch(user, vehicle);
                _context.Add<UserVehicleWatch>(userWatchVehicle);
                _context.SaveChanges();
                return userWatchVehicle;
            }

        }
    }
}
