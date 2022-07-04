using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.EntityFramework
{    //ileride değişiklik olduğunda tüm projenin değişmemesi için şu an entityframework kullandığımızdan dolayı
     //buna ait ve benzer sınıf oluşturarak miras alması sağlandı.
    public class EfSurveyQuestionDal : GenericRepository<SurveyQuestion>, ISurveyQuestionDal
    {
    }
}
