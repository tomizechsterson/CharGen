using StoryTeller;

namespace CharGen.Storyteller.Fixtures
{
    public class DD35HWAFixture : Fixture
    {
        public void CheckAge([SelectionValues("Dwarf", "Elf", "Gnome", "Halfling", "Half-Elf", "Half-Orc", "Human")] string race, 
            [SelectionValues("Barbarian", "Bard", "Cleric", "Druid", "Fighter", "Monk", "Paladin", "Ranger", "Rogue", "Sorcerer", "Wizard")] string className, 
            int lower, int higher)
        {
            throw new StorytellerAssertionException("Not implemented");
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