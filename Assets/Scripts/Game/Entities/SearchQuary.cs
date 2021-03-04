namespace Tartaros.Entities
{
    using System;
    [Flags]
    public enum SearchQuary
    {
        Ally,
        Enemy,
        Neutral,
        Building,
        Unit
    }
}