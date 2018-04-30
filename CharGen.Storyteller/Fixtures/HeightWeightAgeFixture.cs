using ADD2CharacterService.Controllers;
using StoryTeller;

namespace CharGen.Storyteller.Fixtures
{
    public class HeightWeightAgeFixture : Fixture
    {
        private readonly ADD2CharacterController _controller = new ADD2CharacterController();
        private string _race;
        private string _gender;
        
        public void StoreRaceAndGender(string race, string gender)
        {
            _race = race;
            _gender = gender;
        }

        public bool CheckHeight(int lowBound, int highBound)
        {
            int height = _controller.GetHeightWeightAge(_race, _gender)[0];
            return height >= lowBound && height <= highBound;
        }

        public bool CheckWeight(int lowBound, int highBound)
        {
            int weight = _controller.GetHeightWeightAge(_race, _gender)[1];
            return weight >= lowBound && weight <= highBound;
        }

        public bool CheckAge(int lowBound, int highBound)
        {
            int age = _controller.GetHeightWeightAge(_race, _gender)[2];
            return age >= lowBound && age <= highBound;
        }
    }
}