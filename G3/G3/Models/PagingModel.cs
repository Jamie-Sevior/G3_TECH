using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G3.Models
{
    public class PagingModel
    {
        public int page { get; set; } = 1;
        public int count { get; set; } = 25;
        public int Skip => page > 1 ? page * count : 0;
    }
}
