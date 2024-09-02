using AutoMapper;
using FilmeAPI.Data;
using FilmeAPI.Data.Dtos;
using FilmeAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmeAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class EnderecoController : ControllerBase {

    private FilmeContext _context;
    private IMapper _mapper;

    public EnderecoController(FilmeContext context, IMapper mapper) {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]

    public CreatedAtActionResult addEndereco([FromBody] CreateEnderecoDto enderecoDto) { 
        Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
        _context.enderecos.Add(endereco);
        _context.SaveChanges();

        return CreatedAtAction(nameof(getEnderecoById), new { id = endereco.Id }, endereco);
    }

    [HttpGet]
    public IEnumerable<ReadEnderecoDto> getEnderecos([FromQuery] int skip = 0, [FromQuery] int take = 50) {
        return _mapper.Map<List<ReadEnderecoDto>>(_context.enderecos.Skip(skip).Take(take));

    }

    [HttpGet("{id}")]
    public IActionResult getEnderecoById(int id) {
        var endereco = _context.filmes.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null) return NotFound();
        var enderecoDto = _mapper.Map<ReadFilmeDto>(endereco);
        return Ok(endereco);
    }

    [HttpPut("{id}")]
    public IActionResult updateEndereco([FromQuery] int id, [FromBody] UpdateEnderecoDto enderecoDto) {
        var endereco = _context.enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null) return NotFound();

        _mapper.Map(enderecoDto, endereco);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult partialUpdateEndereco(int id, JsonPatchDocument<UpdateEnderecoDto> patch) {

        var endereco = _context.enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null) return NotFound();

        var enderecoForUpdate = _mapper.Map<UpdateEnderecoDto>(endereco);

        patch.ApplyTo(enderecoForUpdate, ModelState);

        if (!TryValidateModel(enderecoForUpdate)) {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(enderecoForUpdate, endereco);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]

    public IActionResult deleteEndereco([FromQuery] int id) {
        var endereco = _context.enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null) return NotFound();
        _context.Remove(endereco);
        _context.SaveChanges();

        return NoContent();
    }

}
