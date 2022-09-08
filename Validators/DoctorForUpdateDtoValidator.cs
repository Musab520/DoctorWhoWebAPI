

using DoctorWho.Web.DtoModels;
using FluentValidation;

namespace DoctorWho.Web.Validators
{
    public class DoctorForUpdateDtoValidator : AbstractValidator<DoctorForUpdateDto>
    {

        public DoctorForUpdateDtoValidator()
        {
            RuleFor(doctor => doctor.DoctorNumber).NotNull().NotEqual(0).WithMessage("Doctor Number Cannot be Empty"); ;
            RuleFor(doctor => doctor.DoctorName).NotNull().NotEmpty().WithMessage("Doctor Name Cannot be Empty or null");
            RuleFor(doctor => doctor.LastEpisodeDate).Null().When(doctor => doctor.FirstEpisodeDate == null).WithMessage("First Episode Date must not be null to enter a LastEpisodeDate");
            RuleFor(doctor => doctor.LastEpisodeDate).GreaterThanOrEqualTo(doctor => doctor.FirstEpisodeDate).WithMessage("LastEpisode Date must be greater than or equal to First Episode Date");
        }

    }
}
