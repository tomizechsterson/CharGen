﻿using System.Linq;
using ADD2CharacterService;
using ADD2CharacterService.Controllers;
using ADD2CharacterService.Datastore;
using StoryTeller;

namespace CharGen.Storyteller.Fixtures
{
    public class ADD2DatastoreFixture : Fixture
    {
        private readonly ADD2CharacterController _controller = new ADD2CharacterController();
        private HttpCharacterModel _character;

        public void Initialize()
        {
            // This name is hardcoded in the controller... Probably a bad thing.
            new DatabaseSetup("characters").Setup();
        }

        public int GetAll()
        {
            return _controller.Get().Count();
        }

        public void RetrieveCharacter(int id)
        {
            _character = _controller.Get(id);
        }

        public string GetRetrievedName()
        {
            return _character.Name;
        }

        public string GetRetrievedPlayedBy()
        {
            return _character.PlayedBy;
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

        public void AddCharacter(string name, string playedBy)
        {
            _controller.Post(new HttpCharacterModel { Name = name, PlayedBy = playedBy });
        }

        public void UpdateCharacter(int id, string name, string playedBy)
        {
            _controller.Put(id, new HttpCharacterModel { Name = name, PlayedBy = playedBy });
        }

        public void UpdateStats(int id, int str, int dex, int con, int @int, int wis, int chr)
        {
            var character = _controller.Get(id);

            _controller.Put(id, new HttpCharacterModel
            {
                Name = character.Name,
                PlayedBy = character.PlayedBy,
                Str = str,
                Dex = dex,
                Con = con,
                Int = @int,
                Wis = wis,
                Chr = chr
            });
        }

        public void UpdateRace(int id, string race)
        {
            var character = _controller.Get(id);

            _controller.Put(id, new HttpCharacterModel
            {
                Name = character.Name,
                PlayedBy = character.PlayedBy,
                Str = character.Str,
                Dex = character.Dex,
                Con = character.Con,
                Int = character.Int,
                Wis = character.Wis,
                Chr = character.Chr,
                Race = race
            });
        }

        public void UpdateGender(int id, string gender)
        {
            var character = _controller.Get(id);

            _controller.Put(id, new HttpCharacterModel
            {
                Name = character.Name,
                PlayedBy = character.PlayedBy,
                Str = character.Str,
                Dex = character.Dex,
                Con = character.Con,
                Int = character.Int,
                Wis = character.Wis,
                Chr = character.Chr,
                Race = character.Race,
                Gender = gender
            });
        }

        public void UpdateHeightWeightAge(int id, int height, int weight, int age)
        {
            var character = _controller.Get(id);
            
            _controller.Put(id, new HttpCharacterModel
            {
                Name = character.Name,
                PlayedBy = character.PlayedBy,
                Str = character.Str,
                Dex = character.Dex,
                Con = character.Con,
                Int = character.Int,
                Wis = character.Wis,
                Chr = character.Chr,
                Race = character.Race,
                Gender = character.Gender,
                Height = height,
                Weight = weight,
                Age = age
            });
        }

        public void DeleteCharacter(int id)
        {
            _controller.Delete(id);
        }

        public void EmptyDatabase()
        {
            _controller.Delete();
        }
    }
}