using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void AdminAdd(Admin admin)
        {
            _adminDal.Insert(admin);
        }

        public void AdminRemove(Admin admin)
        {
            _adminDal.Delete(admin);
        }

        public void AdminUpdate(Admin admin)
        {
            _adminDal.Update(admin);
        }

        public Admin GetAdmin(int id)
        {
            return _adminDal.Get(x=>x.adminID == id);
        }

        public List<Admin> GetAdminsList()
        {
            return _adminDal.List();
        }
    }
}
