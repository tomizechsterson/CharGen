namespace ADD2CharacterService.Race
{
    internal struct AvailableRace
    {
        private readonly string _name;
        private readonly int _minStr;
        private readonly int _maxStr;
        private readonly int _minDex;
        private readonly int _maxDex;
        private readonly int _minCon;
        private readonly int _maxCon;
        private readonly int _minInt;
        private readonly int _maxInt;
        private readonly int _minWis;
        private readonly int _maxWis;
        private readonly int _minChr;
        private readonly int _maxChr;

        public AvailableRace(string name, int minStr, int maxStr, int minDex, int maxDex, int minCon, int maxCon,
            int minInt, int maxInt, int minWis, int maxWis, int minChr, int maxChr)
        {
            _name = name;
            _minStr = minStr;
            _maxStr = maxStr;
            _minDex = minDex;
            _maxDex = maxDex;
            _minCon = minCon;
            _maxCon = maxCon;
            _minInt = minInt;
            _maxInt = maxInt;
            _minWis = minWis;
            _maxWis = maxWis;
            _minChr = minChr;
            _maxChr = maxChr;
        }

        public string Name()
        {
            return _name;
        }

        public bool IsAvailable(int str, int dex, int con, int @int, int wis, int chr)
        {
            return str >= _minStr && str <= _maxStr &&
                   dex >= _minDex && dex <= _maxDex &&
                   con >= _minCon && con <= _maxCon &&
                   @int >= _minInt && @int <= _maxInt &&
                   wis >= _minWis && wis <= _maxWis &&
                   chr >= _minChr && chr <= _maxChr;
        }
    }
}