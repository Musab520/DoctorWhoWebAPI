using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoctorWho.Db;
using DoctorWho.Web.DtoModels;
using DoctorWho.Web.Services;
using AutoMapper;

namespace DoctorWho.Web.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController : Controller
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorsController(IAuthorRepository authorRepository,IMapper mapper)
        {
            _authorRepository = authorRepository ?? throw new ArgumentNullException();
            _mapper = mapper ?? throw new ArgumentNullException();
        }
        [HttpPut("{authorId}")]
        public async Task<ActionResult> UpdateAuthorAsync(int AuthorId,AuthorForUpdateDto authorForUpdateDto)
        {
            Author? author = await _authorRepository.GetAuthorAsync(AuthorId);
            if (author == null)
            {
               return NotFound();
            }
            _mapper.Map(authorForUpdateDto, author);
            await _authorRepository.SaveChangesAsync();
            return NoContent();
        }
    }
}
