using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class PetOwnersController : ControllerBase
  {
    private readonly ApplicationContext _context;
    public PetOwnersController(ApplicationContext context)
    {
      _context = context;
    }

    [HttpGet]
    public IEnumerable<PetOwner> GetPets()
    {
      return _context.PetOwners;
    }

    [HttpPost]
    public IActionResult Post(PetOwner petOwner)
    {
      _context.Add(petOwner);

      _context.SaveChanges();
// CreatedAtAction(nameof(Post), new {Id = newGlasses.Id}, newGlasses);
      return Created("~api/petowners", petOwner);//petOwner);
    }

    [HttpDelete("resource/{id}")]
    public void Delete(int id)
    {
      PetOwner petOwner = _context.PetOwners.Find(id);
      _context.PetOwners.Remove(petOwner);
      _context.SaveChanges();
    }

    [HttpPut("resource/{id}")]
    public PetOwner Put(int id, PetOwner petOwner)
    {
      petOwner.id = id;
      _context.Update(petOwner);
      _context.SaveChanges();
      return petOwner;
    }
  }
}
