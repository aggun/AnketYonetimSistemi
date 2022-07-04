using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using EntityLayer.Concrete;
namespace BussinesLayer.ValidationRules
{
    public class SurveyValidator : AbstractValidator<Survey>
    {    //kullanıcı giriş yaparken istenilen formatta olup olmadığını kontrol etmek için projeye Fluent Validation
         //referans olarak eklendi ardından data katmanındaki veriler getirilerek şartları girildi.
        public SurveyValidator()
        {
            RuleFor(x => x.SurveyName).NotEmpty().WithMessage("Anket adını Boş Geçemezsiniz.");
            RuleFor(x => x.SurveyName).MinimumLength(5).WithMessage("Lütfen En Az 5 Karakter Girişi Yapınız.");
            RuleFor(x => x.SurveyName).MaximumLength(50).WithMessage("Anket adı En Fazla 50 Karakter Olabilir.");
        }
    }
}
