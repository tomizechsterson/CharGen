﻿using System.Collections.Generic;

namespace ADD2CharacterService.Model
{
    public interface ADD2Characters
    {
        IEnumerable<ADD2Character> Iterate();
        ADD2Character Add(string name, string playedby);
    }
}