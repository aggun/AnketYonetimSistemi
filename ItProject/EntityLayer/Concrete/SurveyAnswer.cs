using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{    //sql üzerinde oluşacak tablo ve tablonun sutunları değer bilgisi. ilişkili olacağı diğer tablolar.
    public  class SurveyAnswer
    {
        [Key]
        public int SurveyAnswerId { get; set; }

        [StringLength(200)]
        public string SurveyAnswerText { get; set; }
        public bool SurveyAnsweStatus { get; set; }

        public int? SurveyQuestionId { get; set; }
       public virtual SurveyQuestion SurveyQuestion { get; set; }
        public int? PersonalId { get; set; }
        public virtual Personal Personal { get; set; }

    }
}
