using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{    //sql üzerinde oluşacak tablo ve tablonun sutunları değer bilgisi. ilişkili olacağı diğer tablolar.
    public class Survey
    {
        [Key]
        public int SurveyId { get; set; }
        [StringLength(50)]
        public string SurveyName { get; set; }
        public bool SurveyStatus { get; set; }

        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public ICollection<SurveyQuestion> surveyquestion { get; set; }

    }
}
