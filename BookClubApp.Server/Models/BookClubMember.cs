namespace BookClubApp.Server.Models
{
    public class BookClubMember
    {
        public int BookClubMemberId { get; set; }

        public int? MemberId { get; set; }

        public int? BookClubId { get; set; }

        public int? BookId { get; set; }

        public Book? Book { get; set; }

        public BookClub? BookClub { get; set; }

        public Member? Member { get; set; }
    }
}
