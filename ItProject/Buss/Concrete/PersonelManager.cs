using Buss.Abstract;
using DataAccesLayer.Abstract;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Concrete
{
    public class PersonelManager : IPersonalService
    {    //Interface classın içine implemente edildi ve construcor oluşturularak sınıf yapılarının nesne
         //olarak kullanılmasını sağladık. implemente edilen interface metotlarının içi dolduruldu.
        IPersonalDal _personeldal;
        public PersonelManager(IPersonalDal personeldal)
        {
            _personeldal = personeldal;
        }

        public Personal GetbyId(int id)
        {
            return _personeldal.Get(x => x.PersonalId == id);
        }

        public List<Personal> getlist()
        {
            return _personeldal.List();
        }

        public List<Personal> GetListByPersonalId(int id)
        {
            return _personeldal.List(x => x.PersonalId == id);
        }
        public List<Personal> GetListBycompanyId(int id)
        {
            return _personeldal.List(x => x.CompanyId == id);
        }
        public void PersonalAdd(Personal personal)
        {
            _personeldal.Insert(personal);
        }

        public void PersonalDelete(Personal personal)
        {
            _personeldal.Delete(personal);
        }

        public void PersonalUpdate(Personal personal)
        {
            _personeldal.Update(personal);
        }
    }
}
