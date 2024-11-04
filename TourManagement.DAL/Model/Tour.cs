    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourManagement.DAL.Model
{
    public class Tour
    {
        [Key]
        public int TourId { get; set; }
        public string TourName { get; set; } = string.Empty;
        public float Price { get; set; }
        public string StartTime { get; set; } = string.Empty;
        public string FinishTime { get; set; } = string.Empty;
        public int NumberOfParticipate { get; set; }

        // Navigation properties
        public ICollection<TourDestination> TourDestinations { get; set; } = new List<TourDestination>();

    }
}
