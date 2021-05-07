using UnityEngine;

namespace Abstraction
{
    public interface ITracker
    {
        Vector3 GetPosition();

        GameObject GetTrackedObject();
    }
}