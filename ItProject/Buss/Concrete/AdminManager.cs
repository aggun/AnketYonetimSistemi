using BussinesLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Concrete
{
    //Interface classın içine implemente edildi ve construcor oluşturularak sınıf yapılarının nesne
    //olarak kullanılmasını sağladık. implemente edilen interface metotlarının içi dolduruldu.
    public class AdminManager : IAdminLoginServic
    {
        IAdminDal _adminDal;
        //construcor
        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void Add(Admin admin)
        {
            _adminDal.Insert(admin);
        }

        public void Delete(Admin admin)
        {
            _adminDal.Delete(admin);
        }

        public List<Admin> GetAdmins()
        {
            return _adminDal.List();
        }

        public Admin GetById(int id)
        {
            return _adminDal.Get(a => a.AdminId == id);
        }

        public void Update(Admin admin)
        {
            _adminDal.Update(admin);
        }
    }
}
