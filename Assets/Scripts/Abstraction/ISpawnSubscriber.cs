using System;

namespace Abstraction
{
    public interface ISpawnSubscriber
    {
        bool IsSpawned { get; set; }
        
        void UpdateSubscriber(Action action);
    }
}