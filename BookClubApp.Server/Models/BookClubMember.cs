namespace BookClubApp.Server.Models
{
    public class BookClubMember
    {
        public int BookClubMemberId { get; set; }

        public int MemberId { get; set; }

        public bool BookCompleted { get; set; }

        public int BookId { get; set; }
    }
}
