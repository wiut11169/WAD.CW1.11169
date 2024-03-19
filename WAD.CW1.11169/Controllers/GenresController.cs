using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WAD.CW1._11169.DAL.Dtos;
using WAD.CW1._11169.DAL.Interfaces;
using WAD.CW1._11169.DAL.Models;

namespace WAD.CW1._11169.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GenresController(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreDto>>> GetAllGenres()
        {
            var genres = await _genreRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<GenreDto>>(genres));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GenreDto>> GetGenre(int id)
        {
            var genre = await _genreRepository.GetByIdAsync(id);
            if (genre == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<GenreDto>(genre));
        }

        [HttpPost]
        public async Task<ActionResult<GenreDto>> CreateGenre(GenreDto genreDto)
        {
            var genre = _mapper.Map<Genre>(genreDto);
            await _genreRepository.CreateAsync(genre);
            return Ok(genreDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGenre(int id, GenreDto genreDto)
        {
            if (id != genreDto.Id)
            {
                return BadRequest();
            }

            var genre = await _genreRepository.GetByIdAsync(id);
            if (genre == null)
            {
                return NotFound();
            }

            _mapper.Map(genreDto, genre);
            await _genreRepository.UpdateAsync(genre);
            return Ok("Updated genre with " + id + " Id");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            var genre = await _genreRepository.GetByIdAsync(id);
            if (genre == null)
            {
                return NotFound();
            }

            await _genreRepository.DeleteAsync(id);
            return Ok("Deleted");
        }
    }
}
