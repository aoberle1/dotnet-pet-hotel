using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class PetsController : ControllerBase
  {

    private readonly ApplicationContext _context;
    public PetsController(ApplicationContext context)
    {
      _context = context;
    }

    [HttpGet]
    public IEnumerable<Pet> GetAll()
    {
      return _context.Pets
        .Include((pet) => pet.petOwner);
    }

    [HttpPost]
    public Pet Post(Pet pet)
    {
      Console.WriteLine("CONTEXT!!!!!!!!!!!!!!!!!!!!!!!!!!!!"+_context);

      _context.Add(pet);

      _context.SaveChanges();

      
      return pet;
    }

    [HttpDelete("resource/{id}")]
    public void Delete(int id)
    {
      Pet pet = _context.Pets.Find(id);
      _context.Pets.Remove(pet);
      _context.SaveChanges();
    }

    [HttpPut("resource/{id}")]
    public Pet Put(int id, Pet pet)
    {
      pet.id = id;
      _context.Update(pet);
      _context.SaveChanges();
      return pet;
    }

    // [HttpGet]
    // [Route("test")]
    // public IEnumerable<Pet> GetPets() {
    //     PetOwner blaine = new PetOwner{
    //         name = "Blaine"
    //     };

    //     Pet newPet1 = new Pet {
    //         name = "Big Dog",
    //         petOwner = blaine,
    //         color = PetColorType.Black,
    //         breed = PetBreedType.Poodle,
    //     };

    //     Pet newPet2 = new Pet {
    //         name = "Little Dog",
    //         petOwner = blaine,
    //         color = PetColorType.Golden,
    //         breed = PetBreedType.Labrador,
    //     };

    //     return new List<Pet>{ newPet1, newPet2};
    // }
  }
}
