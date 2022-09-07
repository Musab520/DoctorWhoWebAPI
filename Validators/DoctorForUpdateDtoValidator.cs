

using DoctorWho.Web.DtoModels;
using FluentValidation;

namespace DoctorWho.Web.Validators
{
    public class DoctorForUpdateDtoValidator : AbstractValidator<DoctorForUpdateDto>
    {

        public DoctorForUpdateDtoValidator()
        {
            RuleFor(doctor => doctor.DoctorNumber).NotNull();
            RuleFor(doctor => doctor.DoctorName).NotNull();
            RuleFor(doctor => doctor.LastEpisodeDate).Null().When(doctor => doctor.FirstEpisodeDate == null).WithMessage("First Episode Date must not be null to enter a LastEpisodeDate");
            RuleFor(doctor => doctor.LastEpisodeDate).GreaterThanOrEqualTo(doctor => doctor.FirstEpisodeDate).WithMessage("LastEpisode Date must be greater than or equal to First Episode Date");
        }

    }
}
