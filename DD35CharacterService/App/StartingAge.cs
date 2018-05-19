using System.Collections.Generic;
using System.Linq;
using DD35CharacterService.App.Stats;

namespace DD35CharacterService.App
{
    public class StartingAge
    {
        private readonly string _race;
        private readonly string _className;
        private readonly Dictionary<string, int> _baseAge;
        private readonly Dictionary<string, DD35DieRoll> _modifier;

        public StartingAge(string race, string className)
        {
            _race = race;
            _className = className;
            _baseAge = InitializeBaseAges();
            _modifier = InitializeModifiers();
        }

        public int Get()
        {
            return _baseAge[_race] + _modifier[ModifierKey()].Roll().Sum();
        }

        private string ModifierKey()
        {
            return string.Join(" ", _race, _className);
        }

        private Dictionary<string, int> InitializeBaseAges()
        {
            return new Dictionary<string, int>
            {
                { "Dwarf", 40 },
                { "Elf", 110 },
                { "Gnome", 40 },
                { "Halfling", 20 },
                { "Half-Elf", 20 },
                { "Half-Orc", 14 },
                { "Human", 15 }
            };
        }

        private Dictionary<string, DD35DieRoll> InitializeModifiers()
        {
            var result = new Dictionary<string, DD35DieRoll>
            {
                { "Dwarf Barbarian", new DD35DieRoll(6, 3) },
                { "Dwarf Bard", new DD35DieRoll(6, 5) },
                { "Dwarf Cleric", new DD35DieRoll(6, 7) },
                { "Dwarf Druid", new DD35DieRoll(6, 7) },
                { "Dwarf Fighter", new DD35DieRoll(6, 5) },
                { "Dwarf Monk", new DD35DieRoll(6, 7) },
                { "Dwarf Paladin", new DD35DieRoll(6, 5) },
                { "Dwarf Ranger", new DD35DieRoll(6, 5) },
                { "Dwarf Rogue", new DD35DieRoll(6, 3) },
                { "Dwarf Sorcerer", new DD35DieRoll(6, 3) },
                { "Dwarf Wizard", new DD35DieRoll(6, 7) },
                { "Elf Barbarian", new DD35DieRoll(6, 4) },
                { "Elf Bard", new DD35DieRoll(6, 6) },
                { "Elf Cleric", new DD35DieRoll(6, 10) },
                { "Elf Druid", new DD35DieRoll(6, 10) },
                { "Elf Fighter", new DD35DieRoll(6, 6) },
                { "Elf Monk", new DD35DieRoll(6, 10) },
                { "Elf Paladin", new DD35DieRoll(6, 6) },
                { "Elf Ranger", new DD35DieRoll(6, 6) },
                { "Elf Rogue", new DD35DieRoll(6, 4) },
                { "Elf Sorcerer", new DD35DieRoll(6, 4) },
                { "Elf Wizard", new DD35DieRoll(6, 10) },
                { "Gnome Barbarian", new DD35DieRoll(6, 4) },
                { "Gnome Bard", new DD35DieRoll(6, 6) },
                { "Gnome Cleric", new DD35DieRoll(6, 9) },
                { "Gnome Druid", new DD35DieRoll(6, 9) },
                { "Gnome Fighter", new DD35DieRoll(6, 6) },
                { "Gnome Monk", new DD35DieRoll(6, 9) },
                { "Gnome Paladin", new DD35DieRoll(6, 6) },
                { "Gnome Ranger", new DD35DieRoll(6, 6) },
                { "Gnome Rogue", new DD35DieRoll(6, 4) },
                { "Gnome Sorcerer", new DD35DieRoll(6, 4) },
                { "Gnome Wizard", new DD35DieRoll(6, 9) },
                { "Half-Elf Barbarian", new DD35DieRoll(6, 1) },
                { "Half-Elf Bard", new DD35DieRoll(6, 2) },
                { "Half-Elf Cleric", new DD35DieRoll(6, 3) },
                { "Half-Elf Druid", new DD35DieRoll(6, 3) },
                { "Half-Elf Fighter", new DD35DieRoll(6, 2) },
                { "Half-Elf Monk", new DD35DieRoll(6, 3) },
                { "Half-Elf Paladin", new DD35DieRoll(6, 2) },
                { "Half-Elf Ranger", new DD35DieRoll(6, 2) },
                { "Half-Elf Rogue", new DD35DieRoll(6, 1) },
                { "Half-Elf Sorcerer", new DD35DieRoll(6, 1) },
                { "Half-Elf Wizard", new DD35DieRoll(6, 3) },
                { "Half-Orc Barbarian", new DD35DieRoll(4, 1) },
                { "Half-Orc Bard", new DD35DieRoll(6, 1) },
                { "Half-Orc Cleric", new DD35DieRoll(6, 2) },
                { "Half-Orc Druid", new DD35DieRoll(6, 2) },
                { "Half-Orc Fighter", new DD35DieRoll(6, 1) },
                { "Half-Orc Monk", new DD35DieRoll(6, 2) },
                { "Half-Orc Paladin", new DD35DieRoll(6, 1) },
                { "Half-Orc Ranger", new DD35DieRoll(6, 1) },
                { "Half-Orc Rogue", new DD35DieRoll(4, 1) },
                { "Half-Orc Sorcerer", new DD35DieRoll(4, 1) },
                { "Half-Orc Wizard", new DD35DieRoll(6, 2) },
                { "Halfling Barbarian", new DD35DieRoll(4, 2) },
                { "Halfling Bard", new DD35DieRoll(6, 3) },
                { "Halfling Cleric", new DD35DieRoll(6, 4) },
                { "Halfling Druid", new DD35DieRoll(6, 4) },
                { "Halfling Fighter", new DD35DieRoll(6, 3) },
                { "Halfling Monk", new DD35DieRoll(6, 4) },
                { "Halfling Paladin", new DD35DieRoll(6, 3) },
                { "Halfling Ranger", new DD35DieRoll(6, 3) },
                { "Halfling Rogue", new DD35DieRoll(4, 2) },
                { "Halfling Sorcerer", new DD35DieRoll(4, 2) },
                { "Halfling Wizard", new DD35DieRoll(6, 4) },
                { "Human Barbarian", new DD35DieRoll(4, 1) },
                { "Human Bard", new DD35DieRoll(6, 1) },
                { "Human Cleric", new DD35DieRoll(6, 2) },
                { "Human Druid", new DD35DieRoll(6, 2) },
                { "Human Fighter", new DD35DieRoll(6, 1) },
                { "Human Monk", new DD35DieRoll(6, 2) },
                { "Human Paladin", new DD35DieRoll(6, 1) },
                { "Human Ranger", new DD35DieRoll(6, 1) },
                { "Human Rogue", new DD35DieRoll(4, 1) },
                { "Human Sorcerer", new DD35DieRoll(4, 1) },
                { "Human Wizard", new DD35DieRoll(6, 2) }
            };
            return result;
        }
    }
}