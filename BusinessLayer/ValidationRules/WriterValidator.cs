using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules;

public class WriterValidator : AbstractValidator<Writer>
{
    public WriterValidator()
    {
        RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı soyadı boş geçilemez");
        RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail adresi boş geçilemez");
        RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre Boş Geçilemez ");
        RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("En az 2 karekter girişi yapın");
        RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("En fazla 50 karekter girişi yapın");
    }
}