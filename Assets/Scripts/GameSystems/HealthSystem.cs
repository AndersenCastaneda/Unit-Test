using System;
using UnityEngine;

namespace TestUnity.GameSystems
{
    public sealed class HealthSystem : MonoBehaviour, IHealth
    {
//#pragma warning disable 0649
//        [SerializeField] private IntRefference health;
//#pragma warning restore 0649

        public IntRefference health;

        public void TakeDamage(int damage)
        {
            health.value = (damage > health.value) ? 0 : health.value - damage;
        }

        public void TakeCure(int cure)
        {
            health.value = (health.value + cure > 100) ? 100 : health.value + cure;
        }
    }

    public struct HealthSystemStruct : IHealth
    {
        public IntRefference health;

        public void TakeDamage(int damage)
        {
            health.value = (damage > health.value) ? 0 : health.value - damage;
        }

        public void TakeCure(int cure)
        {
            health.value = (health.value + cure > 100) ? 100 : health.value + cure;
        }
    }
}
