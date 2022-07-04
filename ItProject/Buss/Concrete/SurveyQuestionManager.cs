using Buss.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Concrete
{    //Interface classın içine implemente edildi ve construcor oluşturularak sınıf yapılarının nesne
    //olarak kullanılmasını sağladık. implemente edilen interface metotlarının içi dolduruldu.
    public class SurveyQuestionManager : ISurveyQuestionService
        
    {
        ISurveyQuestionDal _surveyquestiondal;
        public SurveyQuestionManager(ISurveyQuestionDal surveyquestiondal)
        {
            _surveyquestiondal = surveyquestiondal;
        }
        public SurveyQuestion GetbyId(int id)
        {
            return _surveyquestiondal.Get(x => x.SurveyQuestionId == id);
        }

        public List<SurveyQuestion> getlist()
        {
            return _surveyquestiondal.List();
        }

        public List<SurveyQuestion> GetListBySurveyQuestionId(int id)
        {
            return _surveyquestiondal.List(x => x.SurveyId == id);
        }

        public void SurveyQuestionDelete(SurveyQuestion surveyquestion)
        {
            _surveyquestiondal.Delete(surveyquestion);
        }

        public void SurveyQuestionlAdd(SurveyQuestion surveyquestion)
        {
            _surveyquestiondal.Insert(surveyquestion);
        }

        public void SurveyQuestionUpdate(SurveyQuestion surveyquestion)
        {
            _surveyquestiondal.Update(surveyquestion);
        }
    }
}
