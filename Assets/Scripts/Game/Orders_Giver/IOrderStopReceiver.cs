namespace Tartaros.OrderGiver
{
    public interface IOrderStopReceiver
    {
        void Stop();
        void StopAdditive();
    }
}