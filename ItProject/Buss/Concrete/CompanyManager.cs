using Buss.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buss.Concrete
{
    public class CompanyManager : ICompanyService
    {    //Interface classın içine implemente edildi ve construcor oluşturularak sınıf yapılarının nesne
         //olarak kullanılmasını sağladık. implemente edilen interface metotlarının içi dolduruldu.
        ICompanyDal _companydal;

        public CompanyManager(ICompanyDal companydal)
        {
            _companydal = companydal;
        }

        public void CompanyAdd(Company company)
        {
            _companydal.Insert(company);
        }

        public void CompanyDelete(Company company)
        {
            _companydal.Delete(company);
        }

        public void CompanyUpdate(Company company)
        {
            _companydal.Update(company);
        }

        public List<Company> GetListByPersonalId(int id)
        {
            //PersonalId
            return _companydal.List(x => x.CompanyId == id);
        }

        Company ICompanyService.GetbyId(int id)
        {
            return _companydal.Get(x => x.CompanyId == id);
        }

        public List<Company> Getlist()
        {
            return _companydal.List();
        }

        List<Company> ICompanyService.getlist()
        {
            return _companydal.List();
        }
        public Company GetByID(int id)
        {
            return _companydal.Get(x => x.CompanyId == id);
        }
    }
}
