using System.Collections.Generic;
using System.Linq;
using ADD2CharacterService.Controllers;
using ADD2CharacterService.ExceptionHandling;
using StoryTeller;

namespace CharGen.Storyteller.Fixtures
{
    public class ADD2StatRollsFixture : Fixture
    {
        private readonly ADD2CharacterController _controller = new ADD2CharacterController();
        private List<int[]> _rollResults = new List<int[]>();

        public void RollStats(
            [SelectionValues("RollOnce", "RollTwice", "Assignment", "AssignmentDouble", "RollFour", "AddSevenDice")] string rule)
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

        public void CheckNumberOfDiceRolled(int number)
        {
            if (_rollResults.All(x => x.Length != number))
                throw new StorytellerAssertionException($"All rolls didn't use {number} dice");
        }

        public void CheckValuesOfDieRolls(int lower, int higher)
        {
            if (_rollResults.Any(r => r.Sum() < lower))
                throw new StorytellerAssertionException($"There was a roll below {lower}");
            if (_rollResults.Any(r => r.Sum() > higher))
                throw new StorytellerAssertionException($"There was a roll above {higher}");
        }
    }
}