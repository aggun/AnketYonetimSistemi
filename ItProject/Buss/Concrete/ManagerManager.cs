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
   public class ManagerManager : IManagerService
    {    //Interface classın içine implemente edildi ve construcor oluşturularak sınıf yapılarının nesne
         //olarak kullanılmasını sağladık. implemente edilen interface metotlarının içi dolduruldu.
        IManagerDal _managerdal;
        public ManagerManager(IManagerDal managerdal)
        {
            _managerdal = managerdal;
        }
        public Manager GetbyId(int id)
        {
            return _managerdal.Get(x => x.ManagerId == id);
        }

        public List<Manager> getlist()
        {
            return _managerdal.List();
        }

        public List<Manager> GetListById(int id)
        {
            return _managerdal.List(x => x.ManagerId == id);
        }

        public void ManagerAdd(Manager manager)
        {
            _managerdal.Insert(manager);
        }

        public void ManagerDelete(Manager manager)
        {
            _managerdal.Delete(manager);
        }

        public void ManagerUpdate(Manager manager)
        {
            _managerdal.Update(manager);
        }
    }
}
