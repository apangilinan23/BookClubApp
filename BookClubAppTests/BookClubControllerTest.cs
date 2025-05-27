using BookClubApp.Server.Controllers;
using BookClubApp.Server.Models;
using BookClubApp.Server.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace BookClubAppTests
{
    [TestFixture]
    public class BookClubControllerTest
    {
        private Mock<IBookClubService> _bookClubService;
        private BookClubController _bookClubController;

        [SetUp]
        public void SetUp()
        {
            _bookClubService = new Mock<IBookClubService>();
        }

        [Test]
        public void GetAll_Valid_ShouldGetAll()
        {
            //arrange
            var getAllMock = new List<BookClub>
            {
                new BookClub
                {
                    BookClubId = 1,
                    BookClubTitle = "Test",
                }
            };
            _bookClubService.Setup(x => x.GetAll()).Returns(getAllMock);
            _bookClubController = new BookClubController(_bookClubService.Object);

            //act
            var result = _bookClubController.GetAll();

            //assert
            Assert.NotNull(result);
            Assert.AreEqual("Test", result.FirstOrDefault().BookClubTitle);
            _bookClubService.Verify(x => x.GetAll(), Times.Once);
        }

        [Test]
        public void Update_ValidBookClub_ShouldReturn200()
        {
            //arrange
            BookClub paramMock = new BookClub { BookClubTitle = "test title"};
            _bookClubService.Setup(x => x.Update(It.IsAny<BookClub>())).Returns(paramMock);
            _bookClubController = new BookClubController(_bookClubService.Object);

            //act
            var result = _bookClubController.Update(paramMock) as ObjectResult;

            //assert
            Assert.NotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            _bookClubService.Verify(x => x.Update(It.IsAny<BookClub>()), Times.Once);
        }

        [Test]
        public void Update_NullBookClub_ShouldReturn500()
        {
            //arrange
            BookClub paramMock = null;
            _bookClubController = new BookClubController(_bookClubService.Object);

            //act
            var result = _bookClubController.Update(paramMock) as StatusCodeResult;

            //assert
            Assert.NotNull(result);
            Assert.AreEqual(400 ,result.StatusCode);            
            _bookClubService.Verify(x => x.Update(It.IsAny<BookClub>()), Times.Never);
        }
    }
}