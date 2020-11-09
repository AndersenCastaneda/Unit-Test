#if TESTING
#pragma warning disable IDE1006

using NUnit.Framework;
using TestUnity.GameSystems;
using UnityEngine;

namespace Tests
{
    public class TestHealthSystem
    {

        private readonly IntRefference health = ScriptableObject.CreateInstance<IntRefference>();
        private readonly IntRefference maxHealth = ScriptableObject.CreateInstance<IntRefference>();
        private readonly GameObject go = new GameObject();
        private HealthSystem healthSystem;

        [SetUp]
        public void SetTests()
        {
            maxHealth.value = 100;

            if (healthSystem == null)
            {
                healthSystem = go.AddComponent<HealthSystem>();
                healthSystem.health = health;
                healthSystem.maxHealth = maxHealth;
            }
        }

        [Test]
        public void _0_Test_get_60_health_take_40_damage_to_100_health()
        {
            health.value = 100;
            healthSystem.TakeDamage(40);
            Assert.AreEqual(60, health.value);
        }

        [Test]
        public void _1_Test_get_0_health_take_30_damage_to_20_health()
        {
            health.value = 20;
            healthSystem.TakeDamage(30);
            Assert.AreEqual(0, health.value);
        }

        [Test]
        public void _2_Test_get_0_healt_take_20_cure_to_0_health()
        {
            health.value = 0;
            healthSystem.TakeCure(20);
            Assert.AreEqual(0, health.value);
        }

        [Test]
        public void _3_Test_get_80_healt_take_40_cure_to_40_health()
        {
            health.value = 40;
            healthSystem.TakeCure(40);
            Assert.AreEqual(80, health.value);
        }

        [Test]
        public void _4_Test_get_100_health_take_40_cure_to_90_health()
        {
            health.value = 90;
            healthSystem.TakeCure(40);
            Assert.AreEqual(100, health.value);
        }
    }
}
#endif
