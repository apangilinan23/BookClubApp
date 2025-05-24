using BookClubApp.Server.Models;
using BookClubApp.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookClubApp.Server.Controllers
{
    [ApiController]
    [AllowAnonymous]
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
            var model = new BookClub
            {
                BookClubId = bookClub.BookClubId,
                BookClubTitle = bookClub.BookClubTitle
            };

            var updatedBookClub = _bookClubService.Update(model);

            return Ok(updatedBookClub);
        }

        [HttpPost]
        public IActionResult Add(BookClub bookClub)
        {
            var model = new BookClub
            {   
                BookClubTitle = bookClub.BookClubTitle
            };

            _bookClubService.Add(model);
            return Ok(model);
        }

        [HttpDelete("{bookClubId}")]
        public IActionResult Delete(int bookClubId)
        {
            var deleteResult = _bookClubService.Delete(bookClubId);
            return Ok(deleteResult);
        }

    }
}
