using FullStackAuth_WebAPI.Data;
using FullStackAuth_WebAPI.DataTransferObjects;
using FullStackAuth_WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        
        
        private readonly ApplicationDbContext _context;

        public FavoritesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<FavoritesController>
        [HttpGet("myFavorites"), Authorize]
        public IActionResult GetUsersFavorites()
        {
            try
            {
                string userId = User.FindFirstValue("id");

                var favorites = _context.Favorites.
                    Where(f => f.UserId.Equals(userId)).ToList();
                

                
                return StatusCode(200, favorites);
            }
            catch (Exception ex)
            {                               
                return StatusCode(500, ex.Message) ;
            }
        }

        // GET api/<FavoritesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<FavoritesController>
        [HttpPost, Authorize]
        public IActionResult PostFavorite([FromBody] Favorite favorite)
        {
            try
            {
                string userId = User.FindFirstValue("id");

                if (string.IsNullOrEmpty(userId)) 
                {
                    return Unauthorized();
                }

                favorite.UserId = userId;

                _context.Favorites.Add(favorite);
                _context.SaveChanges();

                return StatusCode(201);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<FavoritesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<FavoritesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
