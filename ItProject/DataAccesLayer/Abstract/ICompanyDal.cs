using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace DataAccesLayer.Abstract
{    //Interface içine başka bir interfaceden miras ve parametre alması sağlandı bu BussinesLayer katmanında kullanıdlı.
    public interface ICompanyDal : IRepository<Company>
    {
    }
}
