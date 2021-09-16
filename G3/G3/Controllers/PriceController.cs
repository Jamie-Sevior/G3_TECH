using Microsoft.AspNetCore.Mvc;
using G3.DAL;
using G3.DAL.Models;
using G3.Models;
using G3.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        private readonly Context _context;
        private readonly IPriceProcessor _priceProcessor;

        public PriceController(Context context, IPriceProcessor PriceProcessor)
        {
            _context = context;
            _priceProcessor = PriceProcessor;
        }

        [HttpGet]
        [Route("api/Price/Update/{userId}/{vehicleId}/{newPrice}")]
        public string ChangePrice(int userId, int vehicleId, int newPrice)
        {
            string response = _priceProcessor.PriceUpdate(userId, vehicleId, newPrice);
            return response;
        }
    }
}