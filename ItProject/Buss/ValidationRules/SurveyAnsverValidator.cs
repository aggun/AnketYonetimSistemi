using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using EntityLayer.Concrete;
namespace BussinesLayer.ValidationRules
{
  public  class SurveyAnsverValidator: AbstractValidator<SurveyAnswer>
    {    //kullanıcı giriş yaparken istenilen formatta olup olmadığını kontrol etmek için projeye Fluent Validation
         //referans olarak eklendi ardından data katmanındaki veriler getirilerek şartları girildi.
        public SurveyAnsverValidator()
        { 
        RuleFor(x => x.SurveyAnswerText).NotEmpty().WithMessage("Anket Cevabını Boş Geçemezsiniz.");
        RuleFor(x => x.SurveyAnswerText).MinimumLength(5).WithMessage("Lütfen En Az 5 Karakter Girişi Yapınız.");
        RuleFor(x => x.SurveyAnswerText).MaximumLength(100).WithMessage("Anket Cevabını Adı En Fazla 100 Karakter Olabilir.");
    }
    }
}
