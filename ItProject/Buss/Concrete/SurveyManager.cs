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
    public class SurveyManager : ISurveyService
    {
        ISurveyDal _surveydal;
        public SurveyManager(ISurveyDal surveydal)
        {
            _surveydal = surveydal;
        }

        public Survey GetbyId(int id)
        {
            return _surveydal.Get(x => x.SurveyId == id);
        }

        public List<Survey> getlist()
        {
            return _surveydal.List();
        }

        public List<Survey> GetListBySurveyId(int id)
        {
            return _surveydal.List(x => x.CompanyId == id);
        }

        public void SurveyAdd(Survey survey)
        {
            _surveydal.Insert(survey);
        }

        public void SurveyDelete(Survey survey)
        {
            _surveydal.Delete(survey);
        }

        public void SurveyUpdate(Survey survey)
        {
            _surveydal.Update(survey);
        }
    }
}
