using BookClubApp.Server.Controllers;
using BookClubApp.Server.Models;
using BookClubApp.Server.Services;
using BookClubApp.Server.View_Models;
using Moq;

namespace BookClubAppTests
{
    [TestFixture]
    public class BookClubMemberControllerTest
    {
        private Mock<IBookClubMemberService> _bookClubMemberService;
        private BookClubMemberController _bookClubMemberController;

        [SetUp]
        public void SetUp()
        {
            _bookClubMemberService = new Mock<IBookClubMemberService>();
        }

        [Test]
        public void BookClubMemberController_GetAllByClubId_ShoudGetAll()
        {
            //arrange
            var getAllMock = new List<ClubMemberViewModel>
            {
                new ClubMemberViewModel
                {
                    BooksOnHand = 15,
                    BooksRead = 3,
                    MemberId = 1,
                    Name = "John Doe",
                }
            };
            _bookClubMemberService.Setup(x => x.GetAll(It.IsAny<int>())).Returns(getAllMock);
            _bookClubMemberController = new BookClubMemberController(_bookClubMemberService.Object);

            //act
            var result = _bookClubMemberController.GetAll(It.IsAny<int>());

            //assert
            Assert.NotNull(result);
            Assert.AreEqual("John Doe", result.FirstOrDefault().Name);
            _bookClubMemberService.Verify(x => x.GetAll(It.IsAny<int>()), Times.Once);
        }
    }
}