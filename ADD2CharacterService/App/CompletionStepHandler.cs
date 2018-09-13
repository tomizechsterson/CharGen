using ADD2CharacterService.App.CharacterClass;
using ADD2CharacterService.App.Race;
using ADD2CharacterService.Datastore;

namespace ADD2CharacterService.App
{
    public class CompletionStepHandler
    {
        private enum CompletionSteps
        {
            RaceSelection = 2,
            ClassSelection = 3
        }
        private readonly HttpCharacterModel _model;

        public CompletionStepHandler(HttpCharacterModel model)
        {
            _model = model;
        }

        public HttpCharacterModel Handle()
        {
            if(_model.CompletionStep == (int)CompletionSteps.RaceSelection)
                _model.AvailableRaces =
                    new AvailableRaces(_model.Str, _model.Dex, _model.Con, _model.Int, _model.Wis, _model.Chr).Select();
            else if (_model.CompletionStep == (int)CompletionSteps.ClassSelection)
                _model.AvailableClasses =
                    new AvailableClasses(_model.Race, _model.Str, _model.Dex, _model.Con, _model.Int, _model.Wis, _model.Chr).Select();

            return _model;
        }
    }
}