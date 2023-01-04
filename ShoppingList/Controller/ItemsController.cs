using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Data;
using ShoppingList.Models;
using System.Net.NetworkInformation;

namespace ShoppingList.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly DataContext _context;

        public ItemsController (DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()

        {
            var item = _context.items.ToList();
            

            return Ok(item);
        }


        [HttpPost]

        public ActionResult<Item> AddItem([FromBody] Item item)

        {
           var test = _context.Add(item);
            _context.SaveChangesAsync();
            return Ok(item);

        }
        [HttpPut("{id}")]
        public IActionResult UpdateItem(int id, Item alteracao)
        {
            var item = _context.items.Find(id);

            item.Name = alteracao.Name;
            item.Description = alteracao.Description;
            item.Price = alteracao.Price;

            _context.Update(item);
            _context.SaveChangesAsync();
            return Ok(item);
        }

        [HttpDelete("remove/{id}")]
        public IActionResult RemoveItem(int id)
        {
            var item = _context.items.Find(id);
            _context.Remove(item);
            _context.SaveChangesAsync();
            return Ok(item);
        }

        [HttpGet("get-by-id/{id}")]
        public IActionResult GetById(int id)
        {
            var item = _context.items.Find(id);
            return Ok(item);
        }

        [HttpPost("add-many")]

        public ActionResult<List<Item>> AddMany([FromBody] List<Item> items)

        {
            _context.AddRange(items);
            _context.SaveChangesAsync();
            return Ok(items);

        }

        [HttpGet("get-by-name")]
        public IActionResult GetByName(string name)
        {
            var item = _context.items.Where(i => i.Name.Contains(name)).ToList();
            return Ok(item);
        }



    }
}
