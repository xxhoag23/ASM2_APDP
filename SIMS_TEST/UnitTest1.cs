using SIMS_Demo.Controllers;
using SIMS_Demo.Models;

namespace SIMS_TEST
{
    public class UnitTest1
    {
        [Fact]
        public void TestReadJsonFileWith3Teachers()
        {
            // 1. Arrange

            // 2. Act
            var teachers = TeacherController.ReadFileToTeacherList("data.json");
            // 3. Assert
            Assert.Equal(3, teachers.Count);
        }
    }
}