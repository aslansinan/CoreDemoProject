using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules;

public class CategoryValidator : AbstractValidator<Category>
{
    public CategoryValidator()
    {
        RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adı boş geçilemez");
        RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori açıklaması boş geçilemez");
        RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("Kategori adı en fazla 50 karekter olmalıdır");
        RuleFor(x => x.CategoryName).MinimumLength(2).WithMessage("Kategori adı en az 2 karekter olmalıdır");
    }
    
}