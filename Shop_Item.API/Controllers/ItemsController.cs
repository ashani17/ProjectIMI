using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop_Item.API.Data.DTOs.Item;
using Shop_Item.API.Data.Models;
using Shop_Item.API.Data;

namespace Shop_Item.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {

        private AppDbContext _appDbContext;

        public ItemsController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }



        [HttpPost("AddItem")]


        public IActionResult AddItem([FromBody] PostItemDTO payload)
        {
            var newItem = new Item()

            {
                Name = payload.Name,
                Description = payload.Description,
                Id = payload.Id

            };


            _appDbContext.Item.Add(newItem);
            _appDbContext.SaveChanges();

            return Ok("Objekti u shtua me sukses!");


        }

        [HttpPut("UpdateItem")]


        public IActionResult UpdateItem([FromBody] PostItemDTO payload, int id)
        {
            var item = _appDbContext.Item.FirstOrDefault(x => x.Id == id);

            if (item == null)
                return NotFound();

            item.Name = payload.Name;
            item.Description = payload.Description;
            item.Id = id;


            _appDbContext.Item.Update(item);
            _appDbContext.SaveChanges();


            return Ok("Objekti u modifikua me sukses!");


        }

        [HttpGet("GetItem")]

        public IActionResult GetItem()
        {

            var item = _appDbContext.Item.ToList();
            return Ok(item);



        }

        [HttpGet("GetItemById/{id}")]

        public IActionResult GetItemById(int id)
        {

            var item = _appDbContext.Item.FirstOrDefault(x => x.Id == id);

            return Ok($"Objekti me id = {id} u mor me sukses! ");





        }

        [HttpDelete("Delete Item")]

        public IActionResult DeleteItem(int id)
        {

            var item = _appDbContext.Item.FirstOrDefault(x => x.Id == id);

            if (item == null)
                return NotFound();

            _appDbContext.Item.Remove(item);
            _appDbContext.SaveChanges();

            return Ok($"Objekti me id = {id} u fshi me sukses!");











        }
    }
}
