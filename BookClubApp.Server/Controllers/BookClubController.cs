using BookClubApp.Server.Models;
using BookClubApp.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookClubApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookClubController : ControllerBase
    {
        private readonly IBookClubService _bookClubService;

        public BookClubController(IBookClubService bookClubService)
        {
            _bookClubService = bookClubService;
        }

        [HttpGet()]
        public IEnumerable<BookClub> GetAll()
        {
            return _bookClubService.GetAll();
        }

        [HttpGet("{bookClubId}")]
        public BookClub GetBookClubById(int bookClubId)
        {
            return _bookClubService.Get(bookClubId);
        }

        [HttpPut]
        public IActionResult Update(BookClub bookClub)
        {
            if (bookClub == null)
                return BadRequest();

            var updatedBookClub = _bookClubService.Update(bookClub);

            return Ok(updatedBookClub);
        }

        [HttpPost]
        public IActionResult Add(BookClub bookClub)
        {
            if(bookClub == null)
                return BadRequest();

            _bookClubService.Add(bookClub);
            return Ok(bookClub);
        }

        [HttpDelete("{bookClubId}")]
        public IActionResult Delete(int bookClubId)
        {
            var deleteResult = _bookClubService.Delete(bookClubId);
            return Ok(deleteResult);
        }
    }
}
