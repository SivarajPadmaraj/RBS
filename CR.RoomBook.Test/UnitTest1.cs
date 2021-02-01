using CR.RoomBooking.Services;
using Moq;
using Xunit;

namespace CR.RoomBook.Test
{
    public class UnitTest1
    {
        private readonly Mock<IPersonService> _mockRepo;
        private readonly PersonController _controller;
        public UnitTest1()
        {
            _mockRepo = new Mock<IPersonService>();
            _controller = new PersonController(_mockRepo.Object);
        }
        [Fact]
        public void Test1()
        {


        }
    }
}
