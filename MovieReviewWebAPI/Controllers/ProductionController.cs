using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MovieReviewWebAPI.Dto;
using MovieReviewWebAPI.Interfaces;
using MovieReviewWebAPI.Models;

namespace MovieReviewWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionController : Controller
    {
        private readonly IProductionRepository _productionRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public ProductionController(IProductionRepository productionRepository,
            ICountryRepository countryRepository,
            IMapper mapper)
        {
            _productionRepository = productionRepository;
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Production>))]
        public IActionResult GetProductions()
        {
            var productions = _mapper.Map<List<ProductionDto>>(_productionRepository.GetProductions());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(productions);
        }

        [HttpGet("{productionId}")]
        [ProducesResponseType(200, Type = typeof(Production))]
        [ProducesResponseType(400)]
        public IActionResult GetProduction(int productionId)
        {
            if (!_productionRepository.ProductionExists(productionId))
                return NotFound();

            var production = _mapper.Map<ProductionDto>(_productionRepository.GetProduction(productionId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(production);
        }

        [HttpGet("{productionId}/movie")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Movie>))]
        public IActionResult GetMoviesByProductionId(int productionId)
        {
            if (!_productionRepository.ProductionExists(productionId))
                return NotFound();

            var movies = _mapper.Map<List<MovieDto>>(_productionRepository.GetMoviesByProductionId(productionId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(movies);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateProduction([FromQuery] int countryId, [FromBody] ProductionDto productionCreate)
        {
            if (productionCreate == null)
                return BadRequest(ModelState);

            var productions = _productionRepository.GetProductions()
                .Where(p => p.Name.Trim().ToUpper() == productionCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (productions != null)
            {
                ModelState.AddModelError("", "Production already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var productionMap = _mapper.Map<Production>(productionCreate);

            productionMap.Country = _countryRepository.GetCountry(countryId);

            if (!_productionRepository.CreateProduction(productionMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{productionId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateProduction(int productionId, [FromBody] ProductionDto upatedProduction)
        {
            if (upatedProduction == null)
                return BadRequest(ModelState);

            if (productionId != upatedProduction.Id)
                return BadRequest(ModelState);

            if (!_productionRepository.ProductionExists(productionId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var productionMap = _mapper.Map<Production>(upatedProduction);

            if (!_productionRepository.UpdateProduction(productionMap))
            {
                ModelState.AddModelError("", "Something went wrong updating production");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{productionId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteProduction(int productionId)
        {
            if (!_productionRepository.ProductionExists(productionId))
            {
                return NotFound();
            }

            var productionToDelete = _productionRepository.GetProduction(productionId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_productionRepository.DeleteProduction(productionToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting production");
            }

            return NoContent();
        }
    }
}
