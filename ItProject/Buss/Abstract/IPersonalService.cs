using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buss.Abstract
{
    public interface IPersonalService
    {//Interfaca class içine implemente edileceği için buradan hangi fonksiyonları kullanacağımızı belirledik.
     //EntityLayer ve DataAccesLayer katmanını referans olarak ekledik. Burada EntityLayer katmanı kullanıldı. 
        List<Personal> getlist();
        List<Personal> GetListByPersonalId(int id);
        void PersonalAdd(Personal personal);
        Personal GetbyId(int id);
        void PersonalDelete(Personal personal);
        void PersonalUpdate(Personal personal);
    }
}
