#pragma warning disable 0649

using UnityEngine;

namespace TestUnity.GameSystems
{
    public sealed class HealthSystem : MonoBehaviour, IHealth
    {
#if TESTING
        public IntRefference health;
        public IntRefference maxHealth;
#else
        [SerializeField] private IntRefference health;
        [SerializeField] private readonly IntRefference maxHealth;
#endif

        public void TakeDamage(int damage)
        {
            health.value = (damage >= health.value) ? 0 : health.value - damage;
        }

        public void TakeCure(int cure)
        {
            if (health.value > 0)
                health.value = (health.value + cure >= maxHealth.value) ? maxHealth.value : health.value + cure;
        }
    }
}
