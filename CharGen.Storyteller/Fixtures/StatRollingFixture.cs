using System.Collections.Generic;
using ADD2CharacterService.Controllers;
using StoryTeller;

namespace CharGen.Storyteller.Fixtures
{
    public class StatRollingFixture : Fixture
    {
        private readonly ADD2CharacterController _controller = new ADD2CharacterController();
        private List<int[]> _rollResults = new List<int[]>();

        public void RollOnce()
        {
            var rollResults = new List<int[]>(6);
            for (int i = 0; i < 6; i++)
                rollResults.Add(new int[3] {3, 3, 3});

            _rollResults = rollResults;
        }

        public void RollTwice()
        {
            var rollResults = new List<int[]>(12);
            for (int i = 0; i < 12; i++)
                rollResults.Add(new int[3] { 3, 3, 3 });

            _rollResults = rollResults;
        }

        public int CheckNumberOfRolls()
        {
            return _rollResults.Count;
        }
    }
}