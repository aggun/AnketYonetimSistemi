using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstract
{
    //Interfaca class içine implemente edileceği için buradan hangi fonksiyonları kullanacağımızı belirledik.
    //EntityLayer ve DataAccesLayer katmanını referans olarak ekledik. Burada EntityLayer katmanı kullanıldı. 
   public interface IAdminLoginServic
    {
        //Ekleme fonksiyonu
        void Add(Admin admin);
        //Güncelleme fonksiyonu
        void Update(Admin admin);
        //Silme fonksiyonu
        void Delete(Admin admin);
        //Listeleme fonksiyonu
        List<Admin> GetAdmins();
        //Id getirme fonksiyonu
        Admin GetById(int id);
    }
}
