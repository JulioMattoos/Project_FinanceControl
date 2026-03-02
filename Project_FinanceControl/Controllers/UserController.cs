using FinanceCotrol.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_FinanceControl.Repository;

namespace FinanceCotrol.Controllers;

[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserRepository _repository;

    public UserController(IUserRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<User>> Get()
    {
        var users = _repository.GetAllUsers();
        return Ok(users);
    }

    //continuar implementação repository
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