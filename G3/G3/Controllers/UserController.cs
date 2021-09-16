using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using G3.DAL;
using G3.DAL.Models;
using G3.Models;
using G3.Process;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace G3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Context _context;
        private readonly IWatchVehicleProcessor _watchProcessor;

        public UserController(Context context, IWatchVehicleProcessor watchProcessor)
        {
            _context = context;
            _watchProcessor = watchProcessor;
        }

        [HttpGet]
        public IEnumerable<User> Get([FromQuery] PagingModel model)
        {
            var users = _context.Users.Skip(model.Skip).Take(model.count);
            return users;
        }

        [HttpGet]
        [Route("api/User/TrackedVehicles/{userId}")]
        public IEnumerable<Vehicle> TrackedVehicles(int userId)
        {
            IEnumerable<UserVehicleWatch> userWatchedVehicles = _watchProcessor.GetActiveTrackedByUser(userId);
            IEnumerable<Vehicle> vehicles = new List<Vehicle>();
            foreach (UserVehicleWatch Watched in userWatchedVehicles)
            {
                vehicles.Append<Vehicle>(Watched.Vehicle);
            }
            return vehicles;
        }
    }
}
