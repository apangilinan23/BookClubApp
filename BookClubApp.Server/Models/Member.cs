﻿namespace BookClubApp.Server.Models
{
    public class Member
    {
        public int MemberId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public BookClubMember? BookClubMember { get; set; }
    }
}
