using UnityEngine;

namespace Abstraction
{
    public interface IEnemy : IAliveUnit
    {

        Vector3 PlayerPosition { get; set; }
        void Focus(GameObject focusObj);
        
        bool CanGoForward();

        bool CanJump();
    }
}