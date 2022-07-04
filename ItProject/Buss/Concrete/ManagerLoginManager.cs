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
    public class ManagerLoginManager : IManagerLoginService
    {
        IManagerDal _managerDal;

        public ManagerLoginManager(IManagerDal managerDal)
        {
            _managerDal = managerDal;
        }


        public Manager GetManager(string username, string password)
        {
            return _managerDal.Get(x => x.ManagerUsername == username && x.ManagerPassword == password);
        }
    }
}
