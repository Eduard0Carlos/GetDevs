using System;

namespace Domain.Enums
{
    [Flags]
    public enum Degree
    {
        Ensino_Fundamental = 1,
        Ensino_Médio = 2,
        Ensino_Superior = 4,
        Pós_Graduação = 8,
        Mestrado = 16,
        Doutorado = 32
    }
}
