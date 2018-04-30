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
            return false;
        }

        public bool CheckWeight(int lowBound, int highBound)
        {
            return false;
        }

        public bool CheckAge(int lowBound, int highBound)
        {
            return false;
        }
    }
}