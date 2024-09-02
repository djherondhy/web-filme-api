using AutoMapper;
using FilmeAPI.Data.Dtos;
using FilmeAPI.Data;
using FilmeAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmeAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class SessaoController : Controller {
    private FilmeContext _context;
    private IMapper _mapper;

    public SessaoController(IMapper mapper, FilmeContext context) {
        _mapper = mapper;
        _context = context;
    }

    [HttpPost]
    public CreatedAtActionResult AddSessao([FromBody] CreateSessaoDto sessaoDto) {
        Sessao sessao = _mapper.Map<Sessao>(sessaoDto);
        _context.sessoes.Add(sessao);
        _context.SaveChanges();
        return CreatedAtAction(nameof(getSessaoById), new { id = sessao.Id }, sessao);
    }

    [HttpGet]
    public IEnumerable<ReadSessaoDto> getSessoes([FromQuery] int skip = 0, [FromQuery] int take = 50) {
        var sessaoList = _mapper.Map<List<ReadSessaoDto>>(_context.sessoes.Skip(skip).Take(take));
        return sessaoList;
    }

    [HttpGet("{id}")]
    public IActionResult getSessaoById(int id) {
        var sessao = _context.sessoes.FirstOrDefault(sessao => sessao.Id == id);
        if (sessao == null) return NotFound();
        var sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);
        return Ok(sessaoDto);
    }

   
}
