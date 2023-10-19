using FullStackAuth_WebAPI.Data;
using FullStackAuth_WebAPI.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using FullStackAuth_WebAPI.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookDetailsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BookDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        //// GET: api/<BookDetails>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<BookDetails>/5
        [HttpGet("{id}")]
        public IActionResult GetBookDetails(string bookId)
        {
            try
            {
                string userId = User.FindFirstValue("id");

                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized();
                }

                var bookReviews = _context.Reviews.
                   Where(r => r.BookId.Equals(bookId)).ToList();

                var avgRating = bookReviews.Average(b => b.Rating);
                var isFav = bookReviews.Any(b => b.UserId == userId);
                var userName = _context.Users.Select(u => u.UserName).ToString();
               
                var bookDetail = bookReviews.
                   Select(r => new BookDetailsDto
                   {
                       AvgRating = avgRating,
                       isFavorite = isFav,
                       Review = new ReviewWithUserDto
                       {
                           UserName = userName,
                           Rating = r.Rating,
                           Text = r.Text,
                       }
                   }).ToList();

                return StatusCode(200, bookDetail);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //// POST api/<BookDetails>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<BookDetails>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<BookDetails>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
