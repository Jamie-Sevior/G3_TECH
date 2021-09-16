using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace G3.DAL.Models
{
    public class Notification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Title { get; set; }

        public string Body { get; set; }

        public bool Read { get; set; }

        public Notification()
        {
            this.Read = false;
        }

    }
}
