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

        public void Add(BookClub bookClub)
        {
            try
            {
                _context.BookClubs.Add(bookClub);
                _context.SaveChanges();
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.Message);
            }            
        }

        public bool Delete(int bookClubId)
        {
            var result = false;
            try
            {
                var clubToRemove = _context.BookClubs.FirstOrDefault(x => x.BookClubId == bookClubId);
                if (clubToRemove == null)
                    return false;
                _context.BookClubs.Remove(clubToRemove);
                _context.SaveChanges();
                result = true;
            }
            catch (Exception e)
            {
                _logger.LogError(e.InnerException?.Message);
                result = false;
            }
            return result;
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

        public BookClub Update(BookClub bookClub)
        {
            var bookClubToUpdate = _context.BookClubs.FirstOrDefault(x => x.BookClubId == bookClub.BookClubId);
            bookClubToUpdate.BookClubId = bookClub.BookClubId;
            bookClubToUpdate.BookClubTitle = bookClub.BookClubTitle;
            _context.SaveChanges();

            return bookClubToUpdate;
        }
    }


}
