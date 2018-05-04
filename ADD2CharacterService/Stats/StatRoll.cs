using System;
using System.Collections.Generic;
using ADD2CharacterService.ExceptionHandling;

namespace ADD2CharacterService.Stats
{
    public class StatRoll
    {
        private readonly string _rule;
        private readonly DieRoll _threeSixSidedDice;
        private readonly DieRoll _fourSixSidedDice;
        private readonly DieRoll _oneSixSidedDie;

        public StatRoll(string rule)
        {
            _rule = rule;
            _threeSixSidedDice = new DieRoll(6, 3);
            _fourSixSidedDice = new DieRoll(6, 4);
            _oneSixSidedDie = new DieRoll(6, 1);
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
                            _threeSixSidedDice.Roll(), _threeSixSidedDice.Roll(), _threeSixSidedDice.Roll(),
                            _threeSixSidedDice.Roll(), _threeSixSidedDice.Roll(), _threeSixSidedDice.Roll()
                        };
                    case StatRollingRule.RollTwice:
                        return new List<int[]>(12)
                        {
                            _threeSixSidedDice.Roll(), _threeSixSidedDice.Roll(), _threeSixSidedDice.Roll(),
                            _threeSixSidedDice.Roll(), _threeSixSidedDice.Roll(), _threeSixSidedDice.Roll(),
                            _threeSixSidedDice.Roll(), _threeSixSidedDice.Roll(), _threeSixSidedDice.Roll(),
                            _threeSixSidedDice.Roll(), _threeSixSidedDice.Roll(), _threeSixSidedDice.Roll()
                        };
                    case StatRollingRule.Assignment:
                        return new List<int[]>(6)
                        {
                            _threeSixSidedDice.Roll(), _threeSixSidedDice.Roll(), _threeSixSidedDice.Roll(),
                            _threeSixSidedDice.Roll(), _threeSixSidedDice.Roll(), _threeSixSidedDice.Roll()
                        };
                    case StatRollingRule.AssignmentDouble:
                        return new List<int[]>(12)
                        {
                            _threeSixSidedDice.Roll(), _threeSixSidedDice.Roll(), _threeSixSidedDice.Roll(),
                            _threeSixSidedDice.Roll(), _threeSixSidedDice.Roll(), _threeSixSidedDice.Roll(),
                            _threeSixSidedDice.Roll(), _threeSixSidedDice.Roll(), _threeSixSidedDice.Roll(),
                            _threeSixSidedDice.Roll(), _threeSixSidedDice.Roll(), _threeSixSidedDice.Roll()
                        };
                    case StatRollingRule.RollFour:
                        return new List<int[]>(6)
                        {
                            _fourSixSidedDice.Roll(), _fourSixSidedDice.Roll(), _fourSixSidedDice.Roll(),
                            _fourSixSidedDice.Roll(), _fourSixSidedDice.Roll(), _fourSixSidedDice.Roll()
                        };
                    case StatRollingRule.AddSevenDice:
                        return new List<int[]>(7)
                        {
                            _oneSixSidedDie.Roll(), _oneSixSidedDie.Roll(), _oneSixSidedDie.Roll(),
                            _oneSixSidedDie.Roll(), _oneSixSidedDie.Roll(), _oneSixSidedDie.Roll(),
                            _oneSixSidedDie.Roll()
                        };
                    default:
                        return new List<int[]>();
                }
            }
            
            throw new StatRollRuleInvalidException(nameof(_rule), _rule,
                "The rule to use for rolling stats needs to be one of the six defined in the Player's Handbook");
        }
    }
}