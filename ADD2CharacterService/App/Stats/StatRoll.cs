using System;
using System.Collections.Generic;
using ADD2CharacterService.ExceptionHandling;

namespace ADD2CharacterService.App.Stats
{
    public class StatRoll
    {
        private readonly string _rule;
        private readonly DieRoll _threeSixSidedDice;
        private readonly DieRoll _fourSixSidedDice;
        private readonly DieRoll _oneSixSidedDie;

        public StatRoll(string rule, Random random)
        {
            _rule = rule;
            _threeSixSidedDice = new DieRoll(6, 3, random);
            _fourSixSidedDice = new DieRoll(6, 4, random);
            _oneSixSidedDie = new DieRoll(6, 1, random);
        }

        public List<int[]> RollStats()
        {
            if (Enum.TryParse<StatRollingRule>(_rule, true, out var rule))
            {
                switch (rule)
                {
                    case StatRollingRule.RollOnce:
                        return ThreeSixSidedDieRoll(6);
                    case StatRollingRule.RollTwice:
                        return ThreeSixSidedDieRoll(12);
                    case StatRollingRule.Assignment:
                        return ThreeSixSidedDieRoll(6);
                    case StatRollingRule.AssignmentDouble:
                        return ThreeSixSidedDieRoll(12);
                    case StatRollingRule.RollFour:
                        return FourSixSidedDieRoll(6);
                    case StatRollingRule.AddSevenDice:
                        return OneSixSidedDieRoll(7);
                }
            }

            throw new StatRollRuleInvalidException(nameof(_rule), _rule,
                "The rule to use for rolling stats needs to be one of the six defined in the Player's Handbook");
        }

        private List<int[]> ThreeSixSidedDieRoll(int numRolls)
        {
            var result = new List<int[]>(numRolls);
            for(int i = 0; i < numRolls; i++)
                result.Add(_threeSixSidedDice.Roll());
            return result;
        }
        
        private List<int[]> FourSixSidedDieRoll(int numRolls)
        {
            var result = new List<int[]>(numRolls);
            for(int i = 0; i < numRolls; i++)
                result.Add(_fourSixSidedDice.Roll());
            return result;
        }
        
        private List<int[]> OneSixSidedDieRoll(int numRolls)
        {
            var result = new List<int[]>(numRolls);
            for(int i = 0; i < numRolls; i++)
                result.Add(_oneSixSidedDie.Roll());
            return result;
        }
    }
}