using BookClubApp.Server.Controllers;
using BookClubApp.Server.Models;
using BookClubApp.Server.Services;
using Moq;

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
        public void BookClubController_GetAll_ShouldGetAll()
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
        }
    }
}