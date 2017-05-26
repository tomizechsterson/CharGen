using Xunit;

namespace ADD2CharacterService.Model
{
    public class ADD2CharacterUnitTests
    {
        [Fact]
        public void FirstTest()
        {
            var character = new ADD2Character();

            string value = character.ToString();

            Assert.Equal("", value);
        }
    }

    public class ADD2Character
    {
    }
}