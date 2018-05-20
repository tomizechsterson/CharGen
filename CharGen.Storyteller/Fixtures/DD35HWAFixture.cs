using DD35CharacterService.Controllers;
using StoryTeller;

namespace CharGen.Storyteller.Fixtures
{
    public class DD35HWAFixture : Fixture
    {
        private readonly DD35CharacterController _controller = new DD35CharacterController();
        
        public void CheckAge([SelectionValues("Dwarf", "Elf", "Gnome", "Halfling", "Half-Elf", "Half-Orc", "Human")] string race, 
            [SelectionValues("Barbarian", "Bard", "Cleric", "Druid", "Fighter", "Monk", "Paladin", "Ranger", "Rogue", "Sorcerer", "Wizard")] string className, 
            int lower, int higher)
        {
            int age = _controller.StartingAge(race, className);
            if(age < lower)
                throw new StorytellerAssertionException($"Age {age.ToString()} is lower than {lower.ToString()}");
            if (age > higher)
                throw new StorytellerAssertionException($"Age {age.ToString()} is higher than {higher.ToString()}");
        }

        public void CheckHeight([SelectionValues("Dwarf", "Elf", "Gnome", "Halfling", "Half-Elf", "Half-Orc", "Human")] string race, 
            [SelectionValues("Male", "Female")]string gender, int lower, int higher)
        {
            var heightWeight = _controller.StartingHeightWeight(race, gender == "Male" ? "M" : "F");
            if(heightWeight[0] < lower)
                throw new StorytellerAssertionException($"Starting height {heightWeight[0].ToString()} is lower than {lower.ToString()}");
            if (heightWeight[0] > higher)
                throw new StorytellerAssertionException($"Starting height {heightWeight[0].ToString()} is higher than {higher.ToString()}");
        }
        
        public void CheckWeight([SelectionValues("Dwarf", "Elf", "Gnome", "Halfling", "Half-Elf", "Half-Orc", "Human")] string race, 
            [SelectionValues("Male", "Female")]string gender, int lower, int higher)
        {
            var heightWeight = _controller.StartingHeightWeight(race, gender == "Male" ? "M" : "F");
            if(heightWeight[1] < lower)
                throw new StorytellerAssertionException($"Starting weight {heightWeight[1].ToString()} is lower than {lower.ToString()}");
            if (heightWeight[1] > higher)
                throw new StorytellerAssertionException($"Starting weight {heightWeight[1].ToString()} is higher than {higher.ToString()}");
        }
    }
}