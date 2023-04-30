using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop_Item.API.Data;
using Shop_Item.API.Data.DTOs.Shop;
using Shop_Item.API.Data.Models;

namespace Shop_Item.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopsController : ControllerBase
    {
       


        public AppDbContext _appDbContext;  
        
        public ShopsController (AppDbContext appDbContext)
        {


            _appDbContext = appDbContext;
        }


        [HttpPost("AddShop")]
        public IActionResult AddShops([FromBody] PostShopDTO payload)
        {

            Shop newshop = new Shop()
            {


                Id = payload.Id,
                Name = payload.Name,
                Description = payload.Description,
                Type = payload.Type,




            };


            _appDbContext.Shop.Add(newshop);
            _appDbContext.SaveChanges();




            return Ok("Dyqani u shtua me sukses!");



        }


        [HttpPut]

        public IActionResult UpdateShops([FromBody] PutShopDTO payload, int id)
        {

            var shop = _appDbContext.Shop.FirstOrDefault(x => x.Id == id);

            if (shop == null)
                return NotFound();

            shop.Name = payload.Name;
            shop.Description = payload.Description;
            shop.Id = payload.Id;
            shop.Type = payload.Type;


            _appDbContext.Shop.Update(shop);
            _appDbContext.SaveChanges();

            return Ok("Dyqani u perditesua me sukses!");


        }

        [HttpGet("GetShop")]

        public IActionResult GetShops()
        {

            var shop = _appDbContext.Shop.ToList();


            return Ok(shop);

        }


        [HttpDelete("DeleteShopById/{id}")]


        public IActionResult DeleteShops(int id)
        {


            var shop = _appDbContext.Shop.FirstOrDefault(x => x.Id == id);

            if (shop == null)
                return NotFound();

            _appDbContext.Shop.Remove(shop);
            _appDbContext.SaveChanges();

            return Ok($"Dyqani me id: {id} u fshi me sukses!");


        }



    }
}
