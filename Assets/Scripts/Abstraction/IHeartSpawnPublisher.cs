namespace Abstraction
{
    public interface IHeartSpawnPublisher
    {
        void Subscribe(ISpawnSubscriber spawnSubscriber);

        void Unsubscribe(ISpawnSubscriber spawnSubscriber);

        void Notify();
        
    }
}