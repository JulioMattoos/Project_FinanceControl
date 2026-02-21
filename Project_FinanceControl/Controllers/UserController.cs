using FinanceCotrol.Context;
using FinanceCotrol.Models;
using Microsoft.AspNetCore.Mvc;

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
    public ActionResult<IEnumerable<User>> Get()
    {
        var users = _context.Users.ToList();
        if (users == null)
        {
            return BadRequest("Usuarios não encontrados...");
        }
        return Ok(users);
    }

    [HttpGet("{id}")]
    public ActionResult<User> Get(int id)
    {
        var user = _context.Users.FirstOrDefault(c=> c.UserId == id);
        if(user == null)
        {
            return NotFound("Usuario não encontrado...");
        }
        return Ok(user);
    }

    [HttpPost]
    public ActionResult Post(User user)
    {
        if(user == null)
        {
            return BadRequest("Usuario invalido");
        }
        _context.Users.Add(user);
        return Ok("Usuario criado com sucesso");
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var user = _context.Users.Find(id);
        if(user == null)
        {
            return NotFound("Id invalido");
        }
        _context.Users.Remove(user);
        _context.SaveChanges();
        return Ok("Usuario deletado com sucesso");
    }

}