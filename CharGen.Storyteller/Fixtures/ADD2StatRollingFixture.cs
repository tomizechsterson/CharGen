using System.Collections.Generic;
using System.Linq;
using ADD2CharacterService.Controllers;
using ADD2CharacterService.Stats;
using StoryTeller;

namespace CharGen.Storyteller.Fixtures
{
    public class ADD2StatRollingFixture : Fixture
    {
        private readonly ADD2CharacterController _controller = new ADD2CharacterController();
        private List<int[]> _rollResults = new List<int[]>();

        public void RollOnce()
        {
            _rollResults = _controller.RollStats("RollOnce");
        }

        public void RollTwice()
        {
            _rollResults = _controller.RollStats("RollTwice");
        }

        public void Assignment()
        {
            _rollResults = _controller.RollStats("Assignment");
        }

        public void DoubleAssignment()
        {
            _rollResults = _controller.RollStats("AssignmentDouble");
        }

        public void RollFour()
        {
            _rollResults = _controller.RollStats("RollFour");
        }

        public void AddSevenDice()
        {
            _rollResults = _controller.RollStats("AddSevenDice");
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