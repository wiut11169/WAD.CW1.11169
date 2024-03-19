using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WAD.CW1._11169.DAL.Dtos;
using WAD.CW1._11169.DAL.Interfaces;
using WAD.CW1._11169.DAL.Models;

namespace WAD.CW1._11169.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MoviesController(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetAllMovies()
        {
            var movies = await _movieRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<MovieDto>>(movies));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDto>> GetMovie(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<MovieDto>(movie));
        }

        [HttpPost]
        public async Task<ActionResult<MovieDto>> CreateMovie(MovieDto movieDto)
        {
            var movie = _mapper.Map<Movie>(movieDto);
            await _movieRepository.CreateAsync(movie);
            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, _mapper.Map<MovieDto>(movie));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, MovieDto movieDto)
        {
            if (id != movieDto.Id)
            {
                return BadRequest();
            }

            var movie = await _movieRepository.GetByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _mapper.Map(movieDto, movie);
            await _movieRepository.UpdateAsync(movie);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            await _movieRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
