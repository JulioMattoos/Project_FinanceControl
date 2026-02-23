using FinanceCotrol.Context;
using FinanceCotrol.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

    [HttpGet("{id}", Name = "ObterUsuario")]
    public ActionResult<User> Get(int id)
    {
        var user = _context.Users.FirstOrDefault(c => c.UserId == id);
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

    [HttpPut("{id:int}/user-update")]
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

    [HttpDelete("{id}")]
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