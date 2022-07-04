using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstract
{
    //login işlemi için gerekli değişkenler
    public interface IManagerLoginService
    {
        Manager GetManager(string username, string password);
    }
}
