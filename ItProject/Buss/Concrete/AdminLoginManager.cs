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
    //gelen bilgilerin karşılaştırılma alanı burada true false olarak dönüş gönderilir.
    public class AdminLoginManager : IAdminLoginService
    {
        IAdminDal _adminDal;

        public AdminLoginManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public Admin Getadmin(string username, string password)
        {
            return _adminDal.Get(x => x.AdminUsername == username && x.AdminPassword == password);
        }
    }
}
