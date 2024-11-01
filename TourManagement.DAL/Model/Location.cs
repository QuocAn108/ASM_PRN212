using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourManagement.DAL.Model
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        public string LocationName { get; set; } = string.Empty;
        public string Introduction { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        // Navigation properties
        public ICollection<TourDestination> TourDestinations { get; set; } = new List<TourDestination>();
    }
}
