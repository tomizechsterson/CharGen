using System;
using System.Collections.Generic;

namespace ADD2CharacterService.Stats
{
    public class StatRoll
    {
        private readonly string _rule;

        public StatRoll(string rule)
        {
            _rule = rule;
        }

        public List<int[]> RollStats()
        {
            if (Enum.TryParse<StatRollingRule>(_rule, true, out var rule))
            {
                switch (rule)
                {
                    case StatRollingRule.RollOnce:
                        return new List<int[]>(6)
                        {
                            new DieRoll(6, 3).Roll(), new DieRoll(6, 3).Roll(), new DieRoll(6, 3).Roll(),
                            new DieRoll(6, 3).Roll(), new DieRoll(6, 3).Roll(), new DieRoll(6, 3).Roll()
                        };
                    case StatRollingRule.RollTwice:
                        return new List<int[]>(12)
                        {
                            new DieRoll(6, 3).Roll(), new DieRoll(6, 3).Roll(), new DieRoll(6, 3).Roll(),
                            new DieRoll(6, 3).Roll(), new DieRoll(6, 3).Roll(), new DieRoll(6, 3).Roll(),
                            new DieRoll(6, 3).Roll(), new DieRoll(6, 3).Roll(), new DieRoll(6, 3).Roll(),
                            new DieRoll(6, 3).Roll(), new DieRoll(6, 3).Roll(), new DieRoll(6, 3).Roll()
                        };
                    case StatRollingRule.Assignment:
                        return new List<int[]>(6)
                        {
                            new DieRoll(6, 3).Roll(), new DieRoll(6, 3).Roll(), new DieRoll(6, 3).Roll(),
                            new DieRoll(6, 3).Roll(), new DieRoll(6, 3).Roll(), new DieRoll(6, 3).Roll()
                        };
                    case StatRollingRule.AssignmentDouble:
                        return new List<int[]>(12)
                        {
                            new DieRoll(6, 3).Roll(), new DieRoll(6, 3).Roll(), new DieRoll(6, 3).Roll(),
                            new DieRoll(6, 3).Roll(), new DieRoll(6, 3).Roll(), new DieRoll(6, 3).Roll(),
                            new DieRoll(6, 3).Roll(), new DieRoll(6, 3).Roll(), new DieRoll(6, 3).Roll(),
                            new DieRoll(6, 3).Roll(), new DieRoll(6, 3).Roll(), new DieRoll(6, 3).Roll()
                        };
                    case StatRollingRule.RollFour:
                        return new List<int[]>(6)
                        {
                            new DieRoll(6, 4).Roll(), new DieRoll(6, 4).Roll(), new DieRoll(6, 4).Roll(),
                            new DieRoll(6, 4).Roll(), new DieRoll(6, 4).Roll(), new DieRoll(6, 4).Roll()
                        };
                    case StatRollingRule.AddSevenDice:
                        return new List<int[]>(7)
                        {
                            new DieRoll(6, 1).Roll(), new DieRoll(6, 1).Roll(), new DieRoll(6, 1).Roll(),
                            new DieRoll(6, 1).Roll(), new DieRoll(6, 1).Roll(), new DieRoll(6, 1).Roll(),
                            new DieRoll(6, 1).Roll()
                        };
                    default:
                        return new List<int[]>();
                }
            }
            
            throw new ArgumentOutOfRangeException(nameof(_rule), _rule,
                "The rule to use for rolling stats needs to be one of the six defined in the Player's Handbook");
        }
    }
}