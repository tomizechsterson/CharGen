using System.Collections.Generic;

namespace ADD2CharacterService.Stats
{
    public class StatRoll
    {
        private readonly StatRollingRule _rule;

        public StatRoll(StatRollingRule rule)
        {
            _rule = rule;
        }

        public List<int[]> RollStats()
        {
            switch (_rule)
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
    }
}