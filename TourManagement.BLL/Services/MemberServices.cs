using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourManagement.DAL.Model;
using TourManagement.DAL.Repositories;

namespace TourManagement.BLL.Services
{
    public class MemberServices
    {
        private MemberRepository  _memberRepo = new();
        public Member? CheckLogin(string email, string password)
        {
            return _memberRepo.GetUser(email, password);
        }
        public List<Member> GetAllUser()
        {
            return _memberRepo.GetAll();
        }
        public void AddUser(Member x)
        {
            _memberRepo.Add(x);
        }
        public void UpdateUser(Member x)
        {
            _memberRepo.Update(x);
        }

        public void DeleteUser(Member x)
        {
            _memberRepo.Delete(x);
        }
    }
}
