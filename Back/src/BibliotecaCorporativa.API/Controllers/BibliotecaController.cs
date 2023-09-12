using BibliotecaCorporativa.API.Data;
using BibliotecaCorporativa.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaCorporativa.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BibliotecaController : ControllerBase
{
        private readonly DataContext _context;

    public BibliotecaController(DataContext context)
        {
            _context = context;
            
        }

    [HttpGet]
    public IEnumerable<Livro> Get()
    {
        return _context.Livros;
    }

    [HttpGet("{id}")]
    public Livro GetById(int id)
    {
        return _context.Livros.FirstOrDefault(livro => livro.LivroId == id);
    }

    [HttpPost]
    public string Post()
    {
        return "Exemplo";
    }
}
