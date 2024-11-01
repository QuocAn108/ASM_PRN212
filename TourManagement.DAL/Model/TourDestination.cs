using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourManagement.DAL.Model
{
    public class TourDestination
    {
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public int TourId { get; set; }
        public Tour Tour { get; set; }
        public string Type { get; set; }
    }
}
