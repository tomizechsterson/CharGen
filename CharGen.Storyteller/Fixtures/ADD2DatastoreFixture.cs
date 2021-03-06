﻿using System.Linq;
using System.Threading.Tasks;
using ADD2CharacterService;
using ADD2CharacterService.Controllers;
using ADD2CharacterService.Datastore;
using Microsoft.Data.Sqlite;
using StoryTeller;

namespace CharGen.Storyteller.Fixtures
{
    public class ADD2DatastoreFixture : Fixture
    {
        private readonly SqliteConnection _testConnection = new SqliteConnection("DataSource=:memory:");
        private ADD2CharacterController _controller;
        private HttpCharacterModel _character;

        public override void SetUp()
        {
            new DBSetup(_testConnection).Setup();
            _controller = new ADD2CharacterController(new ADD2SqliteCharacters(_testConnection));
        }

        public void Initialize()
        {
            new DBSetup(_testConnection).Setup();
        }

        public async Task<int> GetAll()
        {
            return (await _controller.Get()).Count();
        }

        public async Task RetrieveCharacter(int id)
        {
            _character = await _controller.Get(id);
        }

        public string GetRetrievedName()
        {
            return _character.Name;
        }

        public void GetRetrievedStats(out int str, out int dex, out int con, out int @int, out int wis, out int chr)
        {
            str = _character.Str;
            dex = _character.Dex;
            con = _character.Con;
            @int = _character.Int;
            wis = _character.Wis;
            chr = _character.Chr;
        }

        public string GetRetrievedRace()
        {
            return _character.Race;
        }

        public string GetRetrievedGender()
        {
            return _character.Gender;
        }

        public void GetRetrievedHeightWeightAge(out int height, out int weight, out int age)
        {
            height = _character.Height;
            weight = _character.Weight;
            age = _character.Age;
        }

        public string GetRetrievedClass()
        {
            return _character.ClassName;
        }

        public string GetRetrievedAlignment()
        {
            return _character.Alignment;
        }

        public void CheckRetrievedHP(int lowBound, int highBound)
        {
            if(_character.HP < lowBound)
                throw new StorytellerAssertionException($"HP {_character.HP} is below {lowBound}");
            if(_character.HP > highBound)
                throw new StorytellerAssertionException($"HP {_character.HP} is above {highBound}");
        }

        public void GetRetrievedSavingThrows(out int paralyze, out int rod, out int petrification, out int breath,
            out int spell)
        {
            paralyze = _character.Paralyze;
            rod = _character.Rod;
            petrification = _character.Petrification;
            breath = _character.Breath;
            spell = _character.Spell;
        }

        public int GetRetrievedMovementRate()
        {
            return _character.MoveRate;
        }

        public void CheckRetrievedInitialFunds(int lowBound, int highBound)
        {
            if (_character.Funds < lowBound)
                throw new StorytellerAssertionException($"Initial funds {_character.Funds} is below {lowBound}");
            if(_character.Funds > highBound)
                throw new StorytellerAssertionException($"Initial funds {_character.Funds} is above {highBound}");
        }

        public async Task AddCharacter(string name)
        {
            await _controller.Post(new HttpCharacterModel { Name = name });
        }

        public async Task UpdateCharacter(int id, string name)
        {
            await _controller.Put(id, new HttpCharacterModel { Name = name, AvailableRaces = new string[0], AvailableClasses = new string[0] });
        }

        public async Task UpdateStats(int id, int str, int dex, int con, int @int, int wis, int chr)
        {
            var character = await _controller.Get(id);

            await _controller.Put(id, new HttpCharacterModel
            {
                Name = character.Name,
                Str = str,
                Dex = dex,
                Con = con,
                Int = @int,
                Wis = wis,
                Chr = chr,
                AvailableRaces = new string[0],
                AvailableClasses = new string[0]
            });
        }

        public async Task UpdateRace(int id, string race)
        {
            var character = await _controller.Get(id);

            await _controller.Put(id, new HttpCharacterModel
            {
                Name = character.Name,
                Str = character.Str,
                Dex = character.Dex,
                Con = character.Con,
                Int = character.Int,
                Wis = character.Wis,
                Chr = character.Chr,
                Race = race,
                AvailableRaces = new string[0],
                AvailableClasses = new string[0]
            });
        }

        public async Task UpdateGender(int id, string gender)
        {
            var character = await _controller.Get(id);

            await _controller.Put(id, new HttpCharacterModel
            {
                Name = character.Name,
                Str = character.Str,
                Dex = character.Dex,
                Con = character.Con,
                Int = character.Int,
                Wis = character.Wis,
                Chr = character.Chr,
                Race = character.Race,
                AvailableRaces = new string[0],
                Gender = gender,
                AvailableClasses = new string[0]
            });
        }

        public async Task UpdateHeightWeightAge(int id, int height, int weight, int age)
        {
            var character = await _controller.Get(id);

            await _controller.Put(id, new HttpCharacterModel
            {
                Name = character.Name,
                Str = character.Str,
                Dex = character.Dex,
                Con = character.Con,
                Int = character.Int,
                Wis = character.Wis,
                Chr = character.Chr,
                Race = character.Race,
                AvailableRaces = new string[0],
                Gender = character.Gender,
                Height = height,
                Weight = weight,
                Age = age,
                AvailableClasses = new string[0]
            });
        }

        public async Task UpdateClass(int id, string className)
        {
            var character = await _controller.Get(id);

            await _controller.Put(id, new HttpCharacterModel
            {
                Name = character.Name,
                Str = character.Str,
                Dex = character.Dex,
                Con = character.Con,
                Int = character.Int,
                Wis = character.Wis,
                Chr = character.Chr,
                Race = character.Race,
                AvailableRaces = new string[0],
                Gender = character.Gender,
                Height = character.Height,
                Weight = character.Weight,
                Age = character.Age,
                ClassName = className,
                AvailableClasses = new string[0]
            });
        }

        public async Task UpdateAlignment(int id, string alignment)
        {
            var character = await _controller.Get(id);

            await _controller.Put(id, new HttpCharacterModel
            {
                Name = character.Name,
                Str = character.Str,
                Dex = character.Dex,
                Con = character.Con,
                Int = character.Int,
                Wis = character.Wis,
                Chr = character.Chr,
                Race = character.Race,
                AvailableRaces = new string[0],
                Gender = character.Gender,
                Height = character.Height,
                Weight = character.Weight,
                Age = character.Age,
                ClassName = character.ClassName,
                AvailableClasses = new string[0],
                Alignment = alignment
            });
        }

        public async Task FinalUpdate(int id, int hp, int paralyze, int rod, int petrification, int breath,
            int spell, int moveRate, int funds)
        {
            var character = await _controller.Get(id);

            await _controller.FinalUpdate(id, new HttpCharacterModel
            {
                Name = character.Name,
                Str = character.Str,
                Dex = character.Dex,
                Con = character.Con,
                Int = character.Int,
                Wis = character.Wis,
                Chr = character.Chr,
                Race = character.Race,
                AvailableRaces = new string[0],
                Gender = character.Gender,
                Height = character.Height,
                Weight = character.Weight,
                Age = character.Age,
                ClassName = character.ClassName,
                AvailableClasses = new string[0],
                Alignment = character.Alignment,
                HP = hp,
                Paralyze = paralyze,
                Rod = rod,
                Petrification = petrification,
                Breath = breath,
                Spell = spell,
                MoveRate = moveRate,
                Funds = funds
            });
        }

        public async Task DeleteCharacter(int id)
        {
            await _controller.Delete(id);
        }

        public async Task EmptyDatabase()
        {
            await _controller.Delete();
        }
    }
}