using BookClubApp.Server.Data;
using BookClubApp.Server.Models;
using BookClubApp.Server.Controllers;

namespace BookClubApp.Server.Services
{
    public class BookClubService : IBookClubService
    {
        private readonly BookClubAppContext _context;
        private readonly ILogger<BookClubController> _logger;

        public BookClubService(BookClubAppContext context, ILogger<BookClubController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public BookClub Get(int bookClubId)
        {
            return _context.BookClubs.FirstOrDefault(x => x.BookClubId == bookClubId);
        }

        public List<BookClub> GetAll()
        {
            var result = new List<BookClub>();
            try
            {
                result.AddRange(_context.BookClubs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return result;
        }
    }


}
