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
            throw new StorytellerAssertionException("Not implemented");
        }
        
        public void CheckWeight([SelectionValues("Dwarf", "Elf", "Gnome", "Halfling", "Half-Elf", "Half-Orc", "Human")] string race, 
            [SelectionValues("Male", "Female")]string gender, int lower, int higher)
        {
            throw new StorytellerAssertionException("Not implemented");
        }
    }
}