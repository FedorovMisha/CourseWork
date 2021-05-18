using Abstraction;
using UnityEngine;

namespace Implementation
{
    public class KillZone : MonoBehaviour, IStaticUnit
    {
        public void Kill()
        {
            Destroy(this.gameObject);   
        }

        public void ToInteract(IAliveUnit unit)
        {
            unit.Kill();
        }
    }
}