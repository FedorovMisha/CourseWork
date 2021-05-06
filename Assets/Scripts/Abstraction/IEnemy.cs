using UnityEngine;

namespace Abstraction
{
    public interface IEnemy : IAliveUnit
    {
        bool CanGoForward();

        bool CanJump();
    }
}