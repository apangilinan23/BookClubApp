﻿namespace BookClubApp.Server.Models
{
    public class BookClub
    {
        public ICollection<BookClubMember>? Members { get; set; }

        public int BookClubId { get; set; }

        public string BookClubTitle { get; set; }
    }
}
