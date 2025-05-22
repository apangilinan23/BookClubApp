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

        [HttpGet(Name = "GetBookClub")]
        public IEnumerable<BookClub> Get()
        {
            return _bookClubService.GetAll();
        }
    }
}
