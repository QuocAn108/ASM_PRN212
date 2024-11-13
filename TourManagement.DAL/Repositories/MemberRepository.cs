using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourManagement.DAL.Data;
using TourManagement.DAL.Model;

namespace TourManagement.DAL.Repositories
{
    public class MemberRepository
    {
        private ApplicationDBContext _context;
        public Member? GetUser(string username, string password)
        {
            _context = new();
            return _context.Members.FirstOrDefault(x => x.Username.ToLower() == username.ToLower() && x.Password == password);
        }
        public List<Member> GetAll()
        {
            _context = new ApplicationDBContext();
            return _context.Members.Where(x => x.Role != "AD").ToList();
        }
        public void Add(Member x)
        {
            _context = new();
            _context.Members.Add(x);
            _context.SaveChanges();
        }
        public void Update(Member x)
        {
            _context = new();
            _context.Members.Update(x);
            _context.SaveChanges();
        }

        public void Delete(Member x)
        {
            _context = new();
            _context.Members.Remove(x);
            _context.SaveChanges();
        }
        public List<Member> SearchMembers(string keyword)
        {
            _context = new ApplicationDBContext();
            return _context.Members
                           .Where(x => x.FullName.Contains(keyword) || x.Role.Contains(keyword))
                           .ToList();
        }
    }
}
