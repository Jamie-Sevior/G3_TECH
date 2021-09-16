using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace G3.DAL.Models
{
    public class UserVehicleWatch
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WatchId { get; set; }
        public int UserId { get; set; }
        public int VehicleId { get; set; }
        public bool Active { get; set; }

        public virtual User User { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        public UserVehicleWatch(User user, Vehicle vehicle)
        {
            this.User = user;
            this.Vehicle = vehicle;
            this.UserId = user.UserId;
            this.VehicleId = vehicle.VehicleId;
            this.Active = true;
        }

        public UserVehicleWatch()
        {

        }
    }
}
