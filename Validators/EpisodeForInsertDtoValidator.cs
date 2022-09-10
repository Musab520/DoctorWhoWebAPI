using DoctorWho.Web.DtoModels;
using FluentValidation;
namespace DoctorWho.Web.Validators
{
    public class EpisodeForInsertDtoValidator :AbstractValidator<EpisodeForInsertDto>
    {
        public EpisodeForInsertDtoValidator()
        {
            RuleFor(episode=>episode.AuthorId).NotEmpty().NotEqual(0);
            RuleFor(episode => episode.DoctorId).NotEmpty().NotEqual(0);
            RuleFor(episode => episode.SeriesNumber.ToString().Length==10);
            RuleFor(episode => episode.EpisodeNumber).GreaterThan(0);
        }
    }
}
