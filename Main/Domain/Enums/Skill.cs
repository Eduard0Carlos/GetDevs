using System;

namespace Domain.Enums
{
    [Flags]
    public enum Skill : long
    {
        None = 0,
        CSharp = 1,
        Java = 2,
        JavaScript = 4,
        //TODO: CHAMAR CELO
    }
}
