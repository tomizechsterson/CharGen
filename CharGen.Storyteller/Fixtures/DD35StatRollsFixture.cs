﻿using System.Collections.Generic;
using System.Linq;
using StoryTeller;

namespace CharGen.Storyteller.Fixtures
{
    public class DD35StatRollsFixture : Fixture
    {
        private List<int[]> _rollResults = new List<int[]>();
        
        public void RollStats()
        {
            _rollResults = new List<int[]>();
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