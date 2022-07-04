using System;
using EntityLayer.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buss.Abstract
{
    public interface ISurveyAnswerService
    {//Interfaca class içine implemente edileceği için buradan hangi fonksiyonları kullanacağımızı belirledik.
     //EntityLayer ve DataAccesLayer katmanını referans olarak ekledik. Burada EntityLayer katmanı kullanıldı. 
        List<SurveyAnswer> getlist();
        List<SurveyAnswer> GetListByHeadingId(int id);
        void SurveyAnswerAdd(SurveyAnswer surveyanswer);
        SurveyAnswer GetbyId(int id);
        void SurveyAnswerDelete(SurveyAnswer surveyanswer);
        void SurveyAnswerUpdate(SurveyAnswer surveyanswer);
    }
}
