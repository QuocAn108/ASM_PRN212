using Microsoft.EntityFrameworkCore;
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
            return _context.TourDestinations.Include("Tour").Include("Location").ToList();
        }

        public bool IsExist(int tourId, int locationId)
        {
            _context = new ApplicationDBContext();
            return _context.TourDestinations.Any(t => t.TourId == tourId && t.LocationId == locationId);
        }

        public void Add(TourDestination tourDestination)
        {
            _context = new ApplicationDBContext();
            _context.TourDestinations.Add(tourDestination);
            _context.SaveChanges();
        }

        public void Delete(TourDestination tourDestination)
        {
            _context = new ApplicationDBContext();
            _context.TourDestinations.Remove(tourDestination);
            _context.SaveChanges();
        }
    }
}
