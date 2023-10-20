using FullStackAuth_WebAPI.Data;
using FullStackAuth_WebAPI.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;


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
        [HttpGet("{bookId}"), Authorize]
        public IActionResult GetBookDetails(string bookId)
        {
            try
            {
                string userId = User.FindFirstValue("id");

                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized();
                }

                var thisUser = _context.Users
                    .Find(userId);
                var userName = thisUser.UserName;

                var bookReviews = _context.Reviews
                    .Include(r => r.User)
                    .Where(r => r.BookId == bookId);
                var isFav = bookReviews.Any(b => b.UserId == userId);
                var avgRating = bookReviews.Average(b => b.Rating);

                var bookDto = bookReviews
                    .Select(r => new BookDetailsDto
                    {
                        
                        AvgRating = avgRating,
                        isFavorite = isFav,
                        //Reviews = reviewDto,
                        Reviews = _context.Reviews
                        .Select(r => new ReviewWithUserDto
                        {
                            UserName = userName,
                            Rating = r.Rating,
                            Text = r.Text,
                        }).ToList()
                    });
                return StatusCode(200, bookDto);
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
