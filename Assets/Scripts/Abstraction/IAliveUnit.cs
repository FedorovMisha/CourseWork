namespace Abstraction
{
    public interface IAliveUnit : IUnit
    {
        void Traffic();

        void Jump();

        void Attack();

        void GetDamage(float damage);
        
        void RestoreHealth(float restoredHealth);
    }
}