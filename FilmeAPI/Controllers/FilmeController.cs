using AutoMapper;
using FilmeAPI.Data;
using FilmeAPI.Data.Dtos;
using FilmeAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmeAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController:ControllerBase {

    private FilmeContext _context;
    private IMapper _mapper;

    public FilmeController(IMapper mapper, FilmeContext context) {
        _mapper = mapper;
        _context = context;
    }

    /// <summary>
    /// Adiciona um filme ao banco de dados
    /// </summary>
    /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    public CreatedAtActionResult AdicionarFilme([FromBody] CreateFilmeDto filmeDto) {
        Filme filme = _mapper.Map<Filme>(filmeDto);
        _context.filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(geFilmeById), new { id = filme.Id }, filme);

        
    }

    /// <summary>
    /// Obtém um filme específico pelo ID
    /// </summary>
    /// <param name="id">ID do filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Filme retornado com sucesso</response>
    /// <response code="404">Filme não encontrado</response>
    [HttpGet]
    public IEnumerable<ReadFilmeDto> getFilmes([FromQuery] int skip = 0, 
        [FromQuery] int take = 50,
        [FromQuery] string? nomeCinema  = null
        ) {

        if (nomeCinema == null) {
            return _mapper.Map<List<ReadFilmeDto>>(_context.filmes.Skip(skip).Take(take)).ToList();
        }

        return _mapper.Map<List<ReadFilmeDto>>(_context.filmes.Skip(skip).Take(take))
            .Where(filme => filme.Sessoes.Any(sessao => sessao.Cinema.Nome == nomeCinema))
            .ToList();

    }


    /// <summary>
    /// Atualiza um filme existente
    /// </summary>
    /// <param name="id">ID do filme a ser atualizado</param>
    /// <param name="filmeDto">Objeto com os dados para atualizar o filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Filme atualizado com sucesso</response>
    /// <response code="404">Filme não encontrado</response>
    [HttpGet("{id}")]
    public IActionResult geFilmeById(int id) {
        var filme = _context.filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();
        var filmeDto = _mapper.Map<ReadFilmeDto>(filme);
        return Ok(filme);
    }

    /// <summary>
    /// Atualiza um filme existente
    /// </summary>
    /// <param name="id">ID do filme a ser atualizado</param>
    /// <param name="filmeDto">Objeto com os dados para atualizar o filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Filme atualizado com sucesso</response>
    /// <response code="404">Filme não encontrado</response>
    [HttpPut("{id}")]
    public IActionResult updateFilme(int id, [FromBody] UpdateFilmeDto filmeDto) {

        var filme = _context.filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();
        _mapper.Map(filmeDto, filme);
        _context.SaveChanges();

        return NoContent();
    }


    /// <summary>
    /// Atualiza parcialmente um filme existente
    /// </summary>
    /// <param name="id">ID do filme a ser atualizado</param>
    /// <param name="patch">Documentação do patch com as alterações parciais</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Filme atualizado parcialmente com sucesso</response>
    /// <response code="404">Filme não encontrado</response>
    /// <response code="400">Problema de validação nos dados fornecidos</response>
    [HttpPatch("{id}")]
    public IActionResult partialUpdateFilme(int id, JsonPatchDocument<UpdateFilmeDto> patch) {

        var filme = _context.filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();
        
        var filmeForUpdate = _mapper.Map<UpdateFilmeDto>(filme);

        patch.ApplyTo(filmeForUpdate, ModelState);

        if(!TryValidateModel(filmeForUpdate)) {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(filmeForUpdate, filme);
        _context.SaveChanges();

        return NoContent();
    }


    /// <summary>
    /// Exclui um filme pelo ID
    /// </summary>
    /// <param name="id">ID do filme a ser excluído</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Filme excluído com sucesso</response>
    /// <response code="404">Filme não encontrado</response>
    [HttpDelete("{id}")]
    public IActionResult deleteFilme(int id) {
        var filme = _context.filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();

        _context.Remove(filme);
        _context.SaveChanges();
        return NoContent(); 
    
    }


}
