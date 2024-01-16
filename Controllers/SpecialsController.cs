using BlazingPizza.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazingPizza.Controllers;
[ApiController]
[Route("specials")]
public class SpecialsController : Controller
{
    private readonly PizzaStoreContext _db;
    public SpecialsController(PizzaStoreContext db)
    {
        _db = db;
    }
    [HttpGet]
    public async Task<ActionResult<List<PizzaSpecial>>> GetSpecials()
    {
        var result = (await _db.Specials.ToListAsync()).OrderByDescending(s=>s.BasePrice).ToList();
        return Ok(result);
    }
    
}