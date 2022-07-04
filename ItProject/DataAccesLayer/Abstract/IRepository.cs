using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Abstract
{    //Interface içine fonksiyonlar eklendi bu fonksiyonları her ınterface iiçin yeniden tanımlamak yerine
    //burada tanımladıktan sonra bir parametre ile diğer class içlerine de implemente edilmesi sağlandı.
    public interface IRepository<T>
    {
        List<T> List();
        void Insert(T p);
        T Get(Expression<Func<T, bool>> filter);
        void Update(T p);
        void Delete(T p);
        List<T> List(Expression<Func<T, bool>> filter);
    }
}
