using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoctorWho.Db;
using AutoMapper;
using DoctorWho.Web.DtoModels;
using DoctorWho.Web.Services;
using DoctorWho.Web.Validators;

namespace DoctorWho.Web.Controllers
{
    [ApiController]
    [Route("api/episodes")]
    public class EpisodesController : Controller
    {
        private readonly IEpisodeRepository _episodeRepository;
        private readonly IMapper _mapper;

        public EpisodesController(IEpisodeRepository episodeRepository,IMapper mapper)
        {
            _episodeRepository = episodeRepository ?? throw new ArgumentNullException(nameof(episodeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EpisodeDto>>> GetEpisodesAsync()
        {
            var episodeEntities = await _episodeRepository.GetEpisodesAsync();
            return Ok(_mapper.Map<IEnumerable<EpisodeDto>>(episodeEntities));
        }
        [HttpPost]
        public async Task<ActionResult> InsertEpisodeAsync(EpisodeForInsertDto episodeDto)
        {
            var episodeValidator = new EpisodeForInsertDtoValidator();
            var episodeValidatorResult=episodeValidator.Validate(episodeDto);
            if (episodeValidatorResult.IsValid)
            {
                Episode episode=_mapper.Map<Episode>(episodeDto);
                await _episodeRepository.InsertEpisodeAsync(episode);
                await _episodeRepository.SaveChangesAsync();
                return NoContent();
            }
            else
            {
                string errorMessages = "";
                episodeValidatorResult.Errors.ForEach(error => errorMessages += error.ErrorMessage + "\n");
                return BadRequest("Bad Request 400: " + errorMessages);
            }
        }
        [HttpPost("EnemyToEpisodes")]
        public async Task<ActionResult> InsertEpisodeEnemyAsync(EpisodeEnemyDto episodeEnemyDto)
        {
            Episode? episode = await _episodeRepository.GetEpisodeAsync(episodeEnemyDto.EpisodeId);
            Enemy? enemy = await _episodeRepository.GetEnemyAsync(episodeEnemyDto.EnemyId);
            if (episode == null || enemy == null)
            {
                return BadRequest("Bad Request 400: Episode or Enemy does not exist");
            }
                EpisodeEnemy episodeEnemy = _mapper.Map<EpisodeEnemy>(episodeEnemyDto);
                await _episodeRepository.InsertEnemytoEpisodeAsync(episodeEnemy);
                await _episodeRepository.SaveChangesAsync();
                return NoContent();
            
        }
        [HttpPost("CompanionToEpisodes")]
        public async Task<ActionResult> InsertEpisodeEnemyAsync(int episodeId, EpisodeCompanionDto episodeCompanionDto)
        {
            Episode? episode = await _episodeRepository.GetEpisodeAsync(episodeCompanionDto.EpisodeId);
            Companion? companion = await _episodeRepository.GetCompanionAsync(episodeCompanionDto.CompanionId);
            if (episode == null || companion == null)
            {
                return BadRequest("Bad Request 400: Episode or Enemy does not exist");
            }
            EpisodeCompanion episodeCompanion = _mapper.Map<EpisodeCompanion>(episodeCompanionDto);
            await _episodeRepository.InsertCompaniontoEpisodeAsync(episodeCompanion);
            await _episodeRepository.SaveChangesAsync();
            return NoContent();

        }
    }
}
