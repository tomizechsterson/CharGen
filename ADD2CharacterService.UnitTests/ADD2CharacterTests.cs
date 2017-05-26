using ADD2CharacterService.Model;
using Xunit;

namespace ADD2CharacterService.UnitTests
{
    public class ADD2CharacterTests
    {
        [Fact]
        public void FirstTest()
        {
            var character = new ADD2Character();

            string value = character.ToString();

            Assert.Equal("", value);
        }

        [Fact]
        public void NameConstructor()
        {
            var character = new ADD2Character("test");

            string value = character.ToString();

            Assert.Equal("test", value);
        }
    }
}
