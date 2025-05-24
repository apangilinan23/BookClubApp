using BookClubApp.Server.Services;
using BookClubApp.Server.View_Models;
using Microsoft.AspNetCore.Mvc;

namespace BookClubApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookClubMemberController : ControllerBase
    {
        private readonly IBookClubMemberService _memberService;
        public BookClubMemberController(IBookClubMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet("{bookClubId}")]
        public IEnumerable<ClubMemberViewModel> GetAll(int bookClubId)
        {
            var result = _memberService.GetAll(bookClubId);
            return result;
        }
    }
}
