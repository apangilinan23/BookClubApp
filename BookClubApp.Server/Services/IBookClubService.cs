using BookClubApp.Server.Models;

namespace BookClubApp.Server.Services
{
    public interface IBookClubService
    {
        public List<BookClub> GetAll();

        public BookClub Get(int bookClubId);
    }
}
