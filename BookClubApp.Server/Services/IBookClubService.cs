﻿using BookClubApp.Server.Models;

namespace BookClubApp.Server.Services
{
    public interface IBookClubService
    {
        public List<BookClub> GetAll();

        public BookClub Get(int bookClubId);

        public BookClub Update(BookClub bookClub);

        public void Add(BookClub bookClub);

        public bool Delete(int bookClubId);
    }
}
