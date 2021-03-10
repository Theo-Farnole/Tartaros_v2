namespace Tartaros.Entities
{
    using System;
    [Flags]
    public enum SearchQuary
    {
        Ally = 0,
        Enemy = 1,
        [Obsolete]
        Neutral = 2,
        Building = 3,
        Unit = 4
    }
}