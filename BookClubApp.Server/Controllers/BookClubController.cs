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
    }
}
