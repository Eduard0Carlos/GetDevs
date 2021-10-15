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
        Ruby = 8,
        Phyton = 16,
        Cobol = 32,
        PHP = 64,
        Algol = 128,
        CPlusPlus = 256,
        C = 512,
        VB = 1024,
        Delphi = 2048,
        Pascal = 4096,
        MathLab = 8192,
        Genexus = 16384,
        HTML = 32768,
        Flutter = 65536,
        SmallTalk = 131072,
        Basic = 262144,
        Fortran = 524288,
        Swift = 1048576,
        ADONet = 2097152,
        EF = 4194304,
        DDD = 8388608,
        MicroService = 16777216,
        TDD = 33554432,
        Subsonic = 67108864,
        NHibernate = 134217728,
        Hibernate = 268435456,
        Docker = 536870912,
        Kubernets = 1073741824,
        Angular = 2147483648,
        React = 4294967296,
        VUEJS = 8589934592,
    }
}
