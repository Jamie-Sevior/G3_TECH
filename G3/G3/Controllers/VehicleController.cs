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
    public class VehicleController : ControllerBase
    {
        private readonly Context _context;
        private readonly IWatchVehicleProcessor _watchProcessor;

        public VehicleController(Context context, IWatchVehicleProcessor watchProcessor)
        {
            _watchProcessor = watchProcessor;
        }

        [HttpGet]
        public IEnumerable<Vehicle> Get([FromQuery] VehicleGetModel model)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("api/Vehicle/Watch/{userId}/{vehicleId}")]
        public bool Watch(int userId, int vehicleId)
        {
            UserVehicleWatch NewVehicleWatch = _watchProcessor.TriggerWatchVehicle(userId, vehicleId);
            if(NewVehicleWatch != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
