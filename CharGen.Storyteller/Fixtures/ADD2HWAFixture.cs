using ADD2CharacterService.Controllers;
using StoryTeller;

namespace CharGen.Storyteller.Fixtures
{
    public class ADD2HWAFixture : Fixture
    {
        private readonly ADD2CharacterController _controller = new ADD2CharacterController();
        private int[] _results;

        public void GivenRaceAndGender(
            [SelectionValues("Dwarf", "Elf", "Gnome", "Half-Elf", "Halfling", "Human")] string race, 
            [SelectionValues("Female", "Male")] string gender)
        {
            _results = _controller.GetHeightWeightAge(race, gender == "Female" ? "F" : "M");
        }

        public void CheckHeight(int lowBound, int highBound)
        {
            int height = _results[0];
            if (height < lowBound)
                throw new StorytellerAssertionException($"{height} is below {lowBound}");
            if (height > highBound)
                throw new StorytellerAssertionException($"{height} is above {highBound}");
        }

        public void CheckWeight(int lowBound, int highBound)
        {
            int weight = _results[1];
            if (weight < lowBound)
                throw new StorytellerAssertionException($"{weight} is below {lowBound}");
            if (weight > highBound)
                throw new StorytellerAssertionException($"{weight} is above {highBound}");
        }

        public void CheckAge(int lowBound, int highBound)
        {
            int age = _results[2];
            if (age < lowBound)
                throw new StorytellerAssertionException($"{age} is below {lowBound}");
            if (age > highBound)
                throw new StorytellerAssertionException($"{age} is above {highBound}");
        }
    }
}