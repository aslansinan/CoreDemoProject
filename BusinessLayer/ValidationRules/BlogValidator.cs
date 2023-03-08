using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules;

public class BlogValidator : AbstractValidator<Blog>
{
    public BlogValidator()
    {
        
        RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog Başlığı boş geçilemez")
            .MaximumLength(150).WithMessage("Lütfen 150 karekterden daha az veri girişi yapınız")
            .MinimumLength(5).WithMessage("Lütfen 4 karekterden daha fazla veri girişi yapınız");
        RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog içeriğini Boş Geçilemez ");
        RuleFor(x => x.BlogImage).MinimumLength(2).WithMessage("Blog görselini Boş Geçilemez");
    }
}