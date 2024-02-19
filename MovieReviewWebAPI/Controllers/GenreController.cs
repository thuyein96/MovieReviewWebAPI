﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieReviewWebAPI.Dto;
using MovieReviewWebAPI.Interfaces;
using MovieReviewWebAPI.Models;

namespace MovieReviewWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : Controller
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GenreController(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Genre>))]
        public IActionResult GetGenres()
        {
            var genres = _mapper.Map<List<GenreDto>>(_genreRepository.GetGenres());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(genres);
        }

        [HttpGet("{genreId}")]
        [ProducesResponseType(200, Type = typeof(Genre))]
        [ProducesResponseType(400)]
        public IActionResult GetGenre(int genreId)
        {
            if (!_genreRepository.GenreExists(genreId))
                return NotFound();

            var genre = _mapper.Map<GenreDto>(_genreRepository.GetGenre(genreId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(genre);
        }

        [HttpGet("movie/{genreId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Movie>))]
        [ProducesResponseType(400)]
        public IActionResult GetMovieByGenreId(int genreId)
        {
            var movie = _mapper.Map<List<MovieDto>>(_genreRepository.GetMovieByGenreId(genreId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(movie);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateGenre([FromBody] GenreDto genreCreate)
        {
            if (genreCreate == null)
                return BadRequest(ModelState);

            var genre = _genreRepository.GetGenres()
                .Where(c => c.Name.Trim().ToUpper() == genreCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (genre != null)
            {
                ModelState.AddModelError("", "Genre already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var genreMap = _mapper.Map<Genre>(genreCreate);

            if (!_genreRepository.CreateGenre(genreMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{genreId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateGenre(int genreId, [FromBody] GenreDto updatedGenre)
        {
            if (updatedGenre == null)
                return BadRequest(ModelState);

            if (genreId != updatedGenre.Id)
                return BadRequest(ModelState);

            if (!_genreRepository.GenreExists(genreId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var genreMap = _mapper.Map<Genre>(updatedGenre);

            if (!_genreRepository.UpdateGenre(genreMap))
            {
                ModelState.AddModelError("", "Something went wrong updating genre");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{genreId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteGenre(int genreId)
        {
            if (!_genreRepository.GenreExists(genreId))
            {
                return NotFound();
            }

            var genreToDelete = _genreRepository.GetGenre(genreId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_genreRepository.DeleteGenre(genreToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting genre");
            }

            return NoContent();
        }
    }
}
