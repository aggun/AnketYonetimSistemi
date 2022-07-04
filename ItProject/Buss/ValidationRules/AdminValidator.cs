using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;
namespace BussinesLayer.ValidationRules
{
    //kullanıcı giriş yaparken istenilen formatta olup olmadığını kontrol etmek için projeye Fluent Validation
    //referans olarak eklendi ardından data katmanındaki veriler getirilerek şartları girildi.
    public class AdminValidator : AbstractValidator<Admin>
    {
        public AdminValidator()
        {
            RuleFor(x => x.AdminName).NotEmpty().WithMessage("Admin Adını Boş Geçemezsiniz.");
            RuleFor(x => x.AdminName).MinimumLength(2).WithMessage("Lütfen En Az 2 Karakter Girişi Yapınız.");
            RuleFor(x => x.AdminName).MaximumLength(30).WithMessage("Admin Adı En Fazla 30 Karakter Olabilir.");
            RuleFor(x => x.AdminSurname).NotEmpty().WithMessage("Admin Soyadını Boş Geçemezsiniz.");
            RuleFor(x => x.AdminSurname).MinimumLength(2).WithMessage("Lütfen En Az 2 Karakter Girişi Yapınız.");
            RuleFor(x => x.AdminSurname).MaximumLength(30).WithMessage("Admin Soyadı En Fazla 30 Karakter Olabilir.");
            RuleFor(x => x.AdminUsername).NotEmpty().WithMessage("Admin Kullanıcı adını Boş Geçemezsiniz.");
            RuleFor(x => x.AdminUsername).MinimumLength(5).WithMessage("Lütfen En Az 5 Karakter Girişi Yapınız.");
            RuleFor(x => x.AdminUsername).MaximumLength(10).WithMessage("Admin Kullanıcı adı En Fazla 10 Karakter Olabilir.");
            RuleFor(x => x.AdminPassword).NotEmpty().WithMessage("Admin Şifresini adını Boş Geçemezsiniz.");
            RuleFor(x => x.AdminPassword).MinimumLength(5).WithMessage("Lütfen En Az 5 Karakter Girişi Yapınız.");
            RuleFor(x => x.AdminPassword).MaximumLength(20).WithMessage("Admin şifresi adı En Fazla 20 Karakter Olabilir.");
        }
    }
}
