using FluentValidation;

namespace BasicSample.Models.Validators
{
    public class CeateOrderValidator : AbstractValidator<TestTagHelper>
    {
        public CeateOrderValidator()
        {
            RuleFor(x => x.OrderName)
                .Length(2, 20)
                .NotEmpty();

            RuleFor(x => x.BirthDay)
                .NotEmpty();

            RuleFor(x => x.Amount)
                .LessThan(15)
                .NotEmpty();

            When(x => !string.IsNullOrEmpty(x.Remark), () =>
            {
                RuleFor(x => x.Remark)
                .MinimumLength(5)
                .WithMessage("客製化錯誤訊息")
                .NotEmpty();
            });

            When(x => x.Delete, () =>
            {
                RuleFor(x => x.Email).NotEmpty();
            });
        }
    }
}