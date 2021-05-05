using UnityEngine;

namespace Abstraction
{
    public interface IAliveUnit : IUnit
    {
        void Traffic();

        void Traffic(Vector3 to);
        
        void Jump();

        void Attack();

        void GetDamage(float damage);
        
        void RestoreHealth(float restoredHealth);
    }
}