namespace Tartaros.Wave
{
    using System;

    public class KilledArgs : EventArgs
    {

    }

    public interface IWaveSpawnable
    {
        event EventHandler<KilledArgs> Killed;
    }
}