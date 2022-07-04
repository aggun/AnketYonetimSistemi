
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstract
{//Interfaca class içine implemente edileceği için buradan hangi fonksiyonları kullanacağımızı belirledik.
 //EntityLayer ve DataAccesLayer katmanını referans olarak ekledik. Burada EntityLayer katmanı kullanıldı. 
    public interface IAuthService
    {
        void Register(string adminMail, string password);
        

        void PersonalRegister(string mail, string password);
    }
}
