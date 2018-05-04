using System.Collections.Generic;
using System.Linq;
using ADD2CharacterService.Controllers;
using ADD2CharacterService.ExceptionHandling;
using StoryTeller;

namespace CharGen.Storyteller.Fixtures
{
    public class ADD2StatRollingFixture : Fixture
    {
        private readonly ADD2CharacterController _controller = new ADD2CharacterController();
        private List<int[]> _rollResults = new List<int[]>();

        public void RollStats([SelectionValues("RollOnce", "RollTwice", "Assignment", "AssignmentDouble", "RollFour", "AddSevenDice")]string rule)
        {
            _rollResults = _controller.RollStats(rule);
        }

        public void RollStatsWithInvalidRule()
        {
            try
            {
                _rollResults = _controller.RollStats("WRONG");
            }
            catch (StatRollRuleInvalidException) {}
        }

        public int CheckNumberOfRolls()
        {
            return _rollResults.Count;
        }

        public bool CheckNumberOfDiceRolled(int number)
        {
            return _rollResults.All(x => x.Length == number);
        }

        public bool CheckValuesOfDieRolls(int lower, int higher)
        {
            return _rollResults.All(roll => roll.Sum() > lower && roll.Sum() < higher);
        }
    }
}