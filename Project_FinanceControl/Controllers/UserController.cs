using FinanceCotrol.Context;
using FinanceCotrol.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FinanceCotrol.Controllers;

[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly FinanceDbContext _context;

    public UserController(FinanceDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> Get()
    {
        try
        {
            var users = await _context.Users.Take(50).ToListAsync();
            if (users == null)
            {
                return BadRequest("Usuarios não encontrados...");
            }
            return Ok(users);
        }
        catch (Exception)
        {
            return StatusCode(500, "Ocorreu um erro ao processar a solicitação.");
        }
        ;
    }

    [HttpGet("{id:int:min(1)}", Name = "ObterUsuario")]
    public async Task<ActionResult<User>> Get(int id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(c => c.UserId == id);
        if (user == null)
        {
            return NotFound("Usuario não encontrado...");
        }
        return Ok(user);
    }

    [HttpPost]
    public ActionResult Post(User user)
    {
        if (user == null)
        {
            return BadRequest();
        }
        _context.Users.Add(user);
        _context.SaveChanges();
        return new CreatedAtRouteResult("ObterUsuario",
            new { id = user.UserId }, user);
    }

    [HttpPut("{id:int:min(1)}/user-update")]
    public ActionResult Put(int id, User user)
    {
        if (id != user.UserId)
        {
            return BadRequest("Id invalido...");
        }
        _context.Entry(user).State = EntityState.Modified;
        _context.SaveChanges();
        return Ok(user);
    }

    [HttpDelete("{id:int:min(1)}")]
    public ActionResult Delete(int id)
    {
        var user = _context.Users.Find(id);
        if (user == null)
        {
            return NotFound("Id invalido");
        }
        _context.Users.Remove(user);
        _context.SaveChanges();
        return Ok("Usuario deletado com sucesso");
    }
}