using Xunit;
using CourseManagement.Models;
using CourseManagement.Repositories;
using System.Linq;

namespace CourseManagement.Tests
{
    public class TestInMemoryRepo
    {
        [Fact]
        public void CanAddAndRetrieveEntity()
        {
            var repo = new InMemoryRepository<OnlineCourse>();

            var course = new OnlineCourse("Math", "zoom", "http://link.com");
            repo.Add(course);

            var all = repo.GetAll().ToList();

            Assert.Single(all);
            Assert.Equal("Math", all.First().Title);
        }

        [Fact]
        public void CanRemoveEntity()
        {
            var repo = new InMemoryRepository<OfflineCourse>();

            var course = new OfflineCourse("Physics", "Room 203", 1);
            repo.Add(course);
            repo.Remove(course);

            Assert.Empty(repo.GetAll());
        }
    }
}
