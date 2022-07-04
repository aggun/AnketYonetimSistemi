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
    public class SurveyAnswerManager : ISurveyAnswerService
    {
        ISurveyAnswerDal _surveyanswerdal;
        public SurveyAnswerManager(ISurveyAnswerDal surveyanswerdal)
        {
            _surveyanswerdal = surveyanswerdal;
        }

        public SurveyAnswer GetbyId(int id)
        {
            return _surveyanswerdal.Get(x => x.SurveyAnswerId == id);
        }

        public List<SurveyAnswer> getlist()
        {
            return _surveyanswerdal.List();
        }

        public List<SurveyAnswer> GetListByHeadingId(int id)
        {
            return _surveyanswerdal.List(x => x.SurveyAnswerId == id);
        }

        public void SurveyAnswerAdd(SurveyAnswer surveyanswer)
        {
            _surveyanswerdal.Insert(surveyanswer);
        }

        public void SurveyAnswerDelete(SurveyAnswer surveyanswer)
        {
            _surveyanswerdal.Delete(surveyanswer);
        }

        public void SurveyAnswerUpdate(SurveyAnswer surveyanswer)
        {
            _surveyanswerdal.Update(surveyanswer);
        }
    }
}
