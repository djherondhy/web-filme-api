using AutoMapper;
using FilmeAPI.Data.Dtos;
using FilmeAPI.Data;
using FilmeAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmeAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CinemaController : Controller {
    private FilmeContext _context;
    private IMapper _mapper;

    public CinemaController(IMapper mapper, FilmeContext context) {
        _mapper = mapper;
        _context = context;
    }

   
    [HttpPost]
    public CreatedAtActionResult AddCinema([FromBody] CreateCinemaDto cinemaDto) {
        Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
        _context.cinemas.Add(cinema);
        _context.SaveChanges();
        return CreatedAtAction(nameof(getCinemaById), new { id = cinema.Id }, cinema);


    }

   
    [HttpGet]
    public IEnumerable<ReadCinemaDto> getCinemas([FromQuery] int? enderecoId = null) {
        
        if (enderecoId == null) {
            var cinemaList = _mapper.Map<List<ReadCinemaDto>>(_context.cinemas.ToList());
            return cinemaList;
        }

        return _mapper.Map<List<ReadCinemaDto>>(
            _context.cinemas
            .FromSqlRaw($"SELECT Id, Nome, EnderecoId FROM cinemas WHERE cinemas.EnderecoId = {enderecoId}").ToList());
       
    }


   
    [HttpGet("{id}")]
    public IActionResult getCinemaById(int id) {
        var cinema = _context.filmes.FirstOrDefault(cinema => cinema.Id == id);
        if (cinema == null) return NotFound();
        var cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
        return Ok(cinema);
    }

   
    /// <response code="404">Filme não encontrado</response>
    [HttpPut("{id}")]
    public IActionResult updateCinema(int id, [FromBody] UpdateCinemaDto cinemaDto) {

        var cinema = _context.filmes.FirstOrDefault(cinema => cinema.Id == id);
        if (cinema == null) return NotFound();
        _mapper.Map(cinemaDto, cinema);
        _context.SaveChanges();

        return NoContent();
    }


    
    [HttpPatch("{id}")]
    public IActionResult partialCinemaFilme(int id, JsonPatchDocument<UpdateCinemaDto> patch) {

        var cinema = _context.filmes.FirstOrDefault(cinema => cinema.Id == id);
        if (cinema == null) return NotFound();

        var cinemaForUpdate = _mapper.Map<UpdateCinemaDto>(cinema);

        patch.ApplyTo(cinemaForUpdate, ModelState);

        if (!TryValidateModel(cinemaForUpdate)) {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(cinemaForUpdate, cinema);
        _context.SaveChanges();

        return NoContent();
    }


    
    [HttpDelete("{id}")]
    public IActionResult cinemaFilme(int id) {
        var cinema = _context.filmes.FirstOrDefault(cinema => cinema.Id == id);
        if (cinema == null) return NotFound();

        _context.Remove(cinema);
        _context.SaveChanges();
        return NoContent();

    }

}
