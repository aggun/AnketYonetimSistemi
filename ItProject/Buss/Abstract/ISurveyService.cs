using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buss.Abstract
{
    public interface ISurveyService
    {//Interfaca class içine implemente edileceği için buradan hangi fonksiyonları kullanacağımızı belirledik.
     //EntityLayer ve DataAccesLayer katmanını referans olarak ekledik. Burada EntityLayer katmanı kullanıldı. 
        List<Survey> getlist();
        List<Survey> GetListBySurveyId(int id);
        void SurveyAdd(Survey survey);
        Survey GetbyId(int id);
        void SurveyDelete(Survey survey);
        void SurveyUpdate(Survey survey);
    }
}
