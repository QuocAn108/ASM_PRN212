using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourManagement.DAL.Data;
using TourManagement.DAL.Model;

namespace TourManagement.DAL.Repositories
{
    public class TourDestinationRepository
    {
        private ApplicationDBContext _context;
        public List<TourDestination> GetAll()
        {
            _context = new();
            return _context.TourDestinations.ToList();
        }

    }
}
