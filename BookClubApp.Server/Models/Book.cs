﻿namespace BookClubApp.Server.Models
{
    public class Book
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public int? BookClubId { get; set; }

        public BookClubMember? BookClubMember { get; set; }
    }
}
