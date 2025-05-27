using BookClubApp.Server.Controllers;
using BookClubApp.Server.Data;
using BookClubApp.Server.Models;
using BookClubApp.Server.View_Models;
using static System.Reflection.Metadata.BlobBuilder;

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
                //1:many
                var clubMemberIds = _context.BookClubs.SelectMany(bc => bc.Members);

                if (!clubMemberIds.Any() || clubMemberIds == null)
                    return result;

                var memberIds = clubMemberIds
                .Where(bc => bc.BookClubId == bookClubId)
                .Select(x => x.MemberId);

                if (!memberIds.Any() || memberIds == null)
                    return result;

                var members = _context.Members.Where(x => memberIds.Contains(x.MemberId));

                result = members.Select(x => new ClubMemberViewModel
                {                    
                    BooksRead =  _context.BookMemberCompletions.Count(c => c.MemberId == x.MemberId),
                    MemberId = x.MemberId,
                    Name = string.Concat(x.FirstName, " ", x.LastName)
                }).ToList();
                
                foreach (var item in result)
                {
                    item.BooksOnHand = GetAllBooksReadByMember(item.MemberId).Books.Count();
                }                
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.InnerException?.Message);
            }
            return result;
        }

        public BooksReadViewModel GetAllBooksReadByMember(int memberId)
        {
            var result = new BooksReadViewModel();
            var clubMemberRecords = _context.BookClubMembers.Where(x => x.MemberId == memberId);
            if (!clubMemberRecords.Any() || clubMemberRecords == null)
                return result;

            var bookIds = clubMemberRecords.Select(x => x.BookId);
            if (!bookIds.Any() || bookIds == null)
                return result;

            var bookList = _context.Books
                .Where(x => bookIds
                .Contains(x.BookId))
                .Select(x => x.Title);

            var bookClubMember = _context.Members.FirstOrDefault(x => x.MemberId == memberId);

            if (bookClubMember == null)
                return result;

            result.Books = bookList.ToList();
            result.Name = $"{string.Concat(bookClubMember.FirstName, " ", bookClubMember.LastName)}";

            return result;
        }
    }
}
