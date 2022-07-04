using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buss.Abstract
{//Interfaca class içine implemente edileceği için buradan hangi fonksiyonları kullanacağımızı belirledik.
 //EntityLayer ve DataAccesLayer katmanını referans olarak ekledik. Burada EntityLayer katmanı kullanıldı. 
    public interface ICompanyService
    {
        List<Company> getlist();
        List<Company> GetListByPersonalId(int id);
        void CompanyAdd(Company company);
        Company GetbyId(int id);
        void CompanyDelete(Company company);
        void CompanyUpdate(Company company);
    }
}
