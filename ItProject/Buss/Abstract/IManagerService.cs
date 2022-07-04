using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstract
{//Interfaca class içine implemente edileceği için buradan hangi fonksiyonları kullanacağımızı belirledik.
    //EntityLayer ve DataAccesLayer katmanını referans olarak ekledik. Burada EntityLayer katmanı kullanıldı. 
    interface IManagerService
    {
        List<Manager> getlist();
        List<Manager> GetListById(int id);
        void ManagerAdd(Manager manager);
        Manager GetbyId(int id);
        void ManagerDelete(Manager manager);
        void ManagerUpdate(Manager manager);
    }
}
