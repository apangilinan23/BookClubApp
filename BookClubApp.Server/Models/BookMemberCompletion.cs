namespace BookClubApp.Server.Models
{
    public class BookMemberCompletion
    {
        public int BookMemberCompletionId { get; set; }

        public int BookId { get; set; }

        public int MemberId { get; set; }
    }
}
