using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using EntityLayer.Concrete;
namespace BussinesLayer.ValidationRules
{
 public   class SurveyQuestionValidator : AbstractValidator<SurveyQuestion>
    {    //kullanıcı giriş yaparken istenilen formatta olup olmadığını kontrol etmek için projeye Fluent Validation
         //referans olarak eklendi ardından data katmanındaki veriler getirilerek şartları girildi.
        public SurveyQuestionValidator()
        {
            RuleFor(x => x.SurveyQuestionText).NotEmpty().WithMessage("Anket Sorusunu Boş Geçemezsiniz.");
            RuleFor(x => x.SurveyQuestionText).MinimumLength(5).WithMessage("Lütfen En Az 52 Karakter Girişi Yapınız.");
            RuleFor(x => x.SurveyQuestionText).MaximumLength(100).WithMessage("Anket Sorusunu En Fazla 100 Karakter Olabilir.");
        }
    }
}
