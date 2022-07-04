using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{    //sql üzerinde oluşacak tablo ve tablonun sutunları değer bilgisi. ilişkili olacağı diğer tablolar.
    public class SurveyQuestion
    {
        [Key]
       public int SurveyQuestionId { get; set; }

     [StringLength(200)]
       public string SurveyQuestionText { get; set; }
        public bool SurveyQuestionStatus { get; set; }

     public int? SurveyId { get; set; }
     public virtual Survey Survey { get; set; }
     public ICollection<SurveyAnswer> surveyAnswers { get; set; }
    }
}
