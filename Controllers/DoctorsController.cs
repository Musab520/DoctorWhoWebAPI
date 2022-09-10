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
using DoctorWho.Web.Validators;
using FluentValidation;

namespace DoctorWho.Web.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IDoctorRepository _doctorRepository;

        public DoctorsController(IDoctorRepository doctorRepository, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _doctorRepository = doctorRepository ?? throw new ArgumentNullException(nameof(doctorRepository));
        }
        [HttpGet(Name = "GetDoctor")]
        public async Task<ActionResult<IEnumerable<DoctorDto>>> GetDoctorsAsync(int DoctorId)
        {
            var doctorEntities = await _doctorRepository.GetDoctorsAsync();
            return Ok(_mapper.Map<IEnumerable<DoctorDto>>(doctorEntities));
        }
        [HttpPost]
        public async Task<ActionResult<DoctorDto>> CreateDoctorAsync(DoctorForInsertDto doctorDto)
        {
            DoctorForInsertDtoValidator doctorValidator = new DoctorForInsertDtoValidator();
            var doctorValidationResult = doctorValidator.Validate(doctorDto);
            if (doctorValidationResult.IsValid)
            {
                Doctor doctor = _mapper.Map<Doctor>(doctorDto);
                await _doctorRepository.InsertDoctorAsync(doctor);
                await _doctorRepository.SaveChangesAsync();
                return CreatedAtRoute("GetDoctor", _mapper.Map<DoctorDto>(doctor),
                doctor);
            }
            else
            {
                string errorMessages = "";
                doctorValidationResult.Errors.ForEach(error => errorMessages += error.ErrorMessage + "\n");
                return BadRequest("Bad Request 400: " + errorMessages);
            }
        }
        [HttpPut("{doctorId}")]
        public async Task<ActionResult> UpdateDoctorAsync(int DoctorId, DoctorForUpdateDto doctorDto)
        {
            DoctorForUpdateDtoValidator doctorValidator = new DoctorForUpdateDtoValidator();
            var doctorValidationResult = doctorValidator.Validate(doctorDto);
            if (doctorValidationResult.IsValid)
            {
                
                Doctor? doctorFound = await _doctorRepository.GetDoctorAsync(DoctorId);
                if (doctorFound==null)
                {
                    return NotFound();
                }
                _mapper.Map(doctorDto,doctorFound);
                await _doctorRepository.SaveChangesAsync();
                return NoContent();
            }
            else
            {
                string errorMessages = "";
                doctorValidationResult.Errors.ForEach(error => errorMessages += error.ErrorMessage + "\n");
                return BadRequest("Bad Request 400: " + errorMessages);
            }
        }
        [HttpDelete("{doctorId}")]
        public async Task<ActionResult> DeleteDoctorAsync(int DoctorId)
        {
            Doctor? doctorFound = _doctorRepository.GetDoctorAsync(DoctorId).Result;
            if (doctorFound == null)
            {
                return NotFound();
            }
            _doctorRepository.DeleteDoctorAsync(doctorFound);
            await _doctorRepository.SaveChangesAsync();
            return NoContent();
        }
    }
}
