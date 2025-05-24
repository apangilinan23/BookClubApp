using BookClubApp.Server.Models;
using BookClubApp.Server.View_Models;

namespace BookClubApp.Server.Services
{
    public interface IBookClubMemberService
    {
        public List<ClubMemberViewModel> GetAll(int bookClubId);
    }
}
