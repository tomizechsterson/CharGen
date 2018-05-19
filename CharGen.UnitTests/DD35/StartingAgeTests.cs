using DD35CharacterService.App;
using Xunit;

namespace CharGen.UnitTests.DD35
{
    public class StartingAgeTests
    {
        [Theory]
        [InlineData("Dwarf", "Barbarian", 43, 58)]
        [InlineData("Dwarf", "Bard", 45, 70)]
        [InlineData("Dwarf", "Cleric", 47, 82)]
        [InlineData("Dwarf", "Druid", 47, 82)]
        [InlineData("Dwarf", "Fighter", 45, 70)]
        [InlineData("Dwarf", "Monk", 47, 82)]
        [InlineData("Dwarf", "Paladin", 45, 70)]
        [InlineData("Dwarf", "Ranger", 45, 70)]
        [InlineData("Dwarf", "Rogue", 43, 58)]
        [InlineData("Dwarf", "Sorcerer", 43, 58)]
        [InlineData("Dwarf", "Wizard", 47, 82)]
        public void Dwarf(string race, string className, int low, int high)
        {
            int age = new StartingAge(race, className).Get();

            Assert.True(age >= low && age <= high);
        }

        [Theory]
        [InlineData("Elf", "Barbarian", 114, 134)]
        [InlineData("Elf", "Bard", 116, 146)]
        [InlineData("Elf", "Cleric", 120, 170)]
        [InlineData("Elf", "Druid", 120, 170)]
        [InlineData("Elf", "Fighter", 116, 146)]
        [InlineData("Elf", "Monk", 120, 170)]
        [InlineData("Elf", "Paladin", 116, 146)]
        [InlineData("Elf", "Ranger", 116, 146)]
        [InlineData("Elf", "Rogue", 114, 134)]
        [InlineData("Elf", "Sorcerer", 114, 134)]
        [InlineData("Elf", "Wizard", 120, 170)]
        public void Elf(string race, string className, int low, int high)
        {
            int age = new StartingAge(race, className).Get();

            Assert.True(age >= low && age <= high);
        }

        [Theory]
        [InlineData("Gnome", "Barbarian", 44, 64)]
        [InlineData("Gnome", "Bard", 46, 76)]
        [InlineData("Gnome", "Cleric", 49, 94)]
        [InlineData("Gnome", "Druid", 49, 94)]
        [InlineData("Gnome", "Fighter", 46, 76)]
        [InlineData("Gnome", "Monk", 49, 94)]
        [InlineData("Gnome", "Paladin", 46, 76)]
        [InlineData("Gnome", "Ranger", 46, 76)]
        [InlineData("Gnome", "Rogue", 44, 64)]
        [InlineData("Gnome", "Sorcerer", 44, 64)]
        [InlineData("Gnome", "Wizard", 49, 94)]
        public void Gnome(string race, string className, int low, int high)
        {
            int age = new StartingAge(race, className).Get();

            Assert.True(age >= low && age <= high);
        }

        [Theory]
        [InlineData("Halfling", "Barbarian", 22, 28)]
        [InlineData("Halfling", "Bard", 23, 38)]
        [InlineData("Halfling", "Cleric", 24, 44)]
        [InlineData("Halfling", "Druid", 24, 44)]
        [InlineData("Halfling", "Fighter", 23, 38)]
        [InlineData("Halfling", "Monk", 24, 44)]
        [InlineData("Halfling", "Paladin", 23, 38)]
        [InlineData("Halfling", "Ranger", 23, 38)]
        [InlineData("Halfling", "Rogue", 22, 28)]
        [InlineData("Halfling", "Sorcerer", 22, 28)]
        [InlineData("Halfling", "Wizard", 24, 44)]
        public void Halfling(string race, string className, int low, int high)
        {
            int age = new StartingAge(race, className).Get();

            Assert.True(age >= low && age <= high);
        }
        
        [Theory]
        [InlineData("Half-Elf", "Barbarian", 21, 26)]
        [InlineData("Half-Elf", "Bard", 22, 32)]
        [InlineData("Half-Elf", "Cleric", 23, 38)]
        [InlineData("Half-Elf", "Druid", 23, 38)]
        [InlineData("Half-Elf", "Fighter", 22, 32)]
        [InlineData("Half-Elf", "Monk", 23, 38)]
        [InlineData("Half-Elf", "Paladin", 22, 32)]
        [InlineData("Half-Elf", "Ranger", 22, 32)]
        [InlineData("Half-Elf", "Rogue", 21, 26)]
        [InlineData("Half-Elf", "Sorcerer", 21, 26)]
        [InlineData("Half-Elf", "Wizard", 23, 38)]
        public void HalfElf(string race, string className, int low, int high)
        {
            int age = new StartingAge(race, className).Get();

            Assert.True(age >= low && age <= high);
        }

        [Theory]
        [InlineData("Half-Orc", "Barbarian", 15, 18)]
        [InlineData("Half-Orc", "Bard", 15, 20)]
        [InlineData("Half-Orc", "Cleric", 16, 26)]
        [InlineData("Half-Orc", "Druid", 16, 26)]
        [InlineData("Half-Orc", "Fighter", 15, 20)]
        [InlineData("Half-Orc", "Monk", 16, 26)]
        [InlineData("Half-Orc", "Paladin", 15, 20)]
        [InlineData("Half-Orc", "Ranger", 15, 20)]
        [InlineData("Half-Orc", "Rogue", 15, 18)]
        [InlineData("Half-Orc", "Sorcerer", 15, 18)]
        [InlineData("Half-Orc", "Wizard", 16, 26)]
        public void HalfOrc(string race, string className, int low, int high)
        {
            int age = new StartingAge(race, className).Get();

            Assert.True(age >= low && age <= high);
        }
        
        [Theory]
        [InlineData("Human", "Barbarian", 16, 19)]
        [InlineData("Human", "Bard", 16, 21)]
        [InlineData("Human", "Cleric", 17, 27)]
        [InlineData("Human", "Druid", 17, 27)]
        [InlineData("Human", "Fighter", 16, 21)]
        [InlineData("Human", "Monk", 17, 27)]
        [InlineData("Human", "Paladin", 16, 21)]
        [InlineData("Human", "Ranger", 16, 21)]
        [InlineData("Human", "Rogue", 16, 19)]
        [InlineData("Human", "Sorcerer", 16, 19)]
        [InlineData("Human", "Wizard", 17, 27)]
        public void Human(string race, string className, int low, int high)
        {
            int age = new StartingAge(race, className).Get();

            Assert.True(age >= low && age <= high);
        }
    }
}