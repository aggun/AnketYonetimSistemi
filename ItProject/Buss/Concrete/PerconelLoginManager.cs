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
    public class PerconelLoginManager :IPersonelLoginService
    {
        IPersonalDal _personalDal;

        public PerconelLoginManager(IPersonalDal personalDal)
        {
            _personalDal = personalDal;
        }

        public Personal GetPersonel(string username, string password)
        {
           return _personalDal.Get(x => x.PersonalUsername == username && x.PersonalPassword == password);
        }
    }
}
