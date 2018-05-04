using System;

namespace ADD2CharacterService.ExceptionHandling
{
    public class StatRollRuleInvalidException : ArgumentOutOfRangeException
    {
        public StatRollRuleInvalidException(string paramName, string paramValue, string message) : base(paramName, paramValue, message) {}
    }
}