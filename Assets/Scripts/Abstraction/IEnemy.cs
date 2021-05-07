using UnityEngine;

namespace Abstraction
{
    public interface IEnemy : IAliveUnit
    {

        void Focus(GameObject focusObj);
        
        bool CanGoForward();

        bool CanJump();
    }
}