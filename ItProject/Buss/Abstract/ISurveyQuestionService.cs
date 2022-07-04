using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buss.Abstract
{
    public interface ISurveyQuestionService
    {//Interfaca class içine implemente edileceği için buradan hangi fonksiyonları kullanacağımızı belirledik.
     //EntityLayer ve DataAccesLayer katmanını referans olarak ekledik. Burada EntityLayer katmanı kullanıldı. 
        List<SurveyQuestion> getlist();
        List<SurveyQuestion> GetListBySurveyQuestionId(int id);
        void SurveyQuestionlAdd(SurveyQuestion surveyquestion);
        SurveyQuestion GetbyId(int id);
        void SurveyQuestionDelete(SurveyQuestion surveyquestion);
        void SurveyQuestionUpdate(SurveyQuestion surveyquestion);
    }
}
