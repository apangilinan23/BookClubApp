using BookClubApp.Server.Controllers;
using BookClubApp.Server.Data;
using BookClubApp.Server.View_Models;

namespace BookClubApp.Server.Services
{
    public class BookClubMemberService : IBookClubMemberService
    {
        private readonly BookClubAppContext _context;
        private readonly ILogger<BookClubMemberController> _logger;

        public BookClubMemberService(BookClubAppContext context, ILogger<BookClubMemberController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public List<ClubMemberViewModel> GetAll(int bookClubId)
        {
            List<ClubMemberViewModel> result = new List<ClubMemberViewModel>();
            try
            {
                var clubMemberIds = _context.BookClubs.SelectMany(bc => bc.Members)
                .Where(bc => bc.BookClubId == bookClubId)
                .Select(x => x.MemberId);

                var members = _context.Members.Where(x => clubMemberIds.Contains(x.MemberId));

                result = members.Select(x => new ClubMemberViewModel
                {
                    BooksRead = _context.BookMemberCompletions.Count(c => c.MemberId == x.MemberId),
                    MemberId = x.MemberId,
                    Name = string.Concat(x.FirstName, " ", x.LastName)
                }).ToList();
                
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.InnerException?.Message);
            }
            return result;
        }
    }
}
