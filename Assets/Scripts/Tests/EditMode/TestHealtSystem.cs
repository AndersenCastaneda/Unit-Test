using NUnit.Framework;
using TestUnity.GameSystems;
using UnityEngine;

namespace Tests
{
    public class TestHealthSystem
    {
#pragma warning disable

        private readonly IntRefference health = ScriptableObject.CreateInstance<IntRefference>();
        private readonly GameObject go = new GameObject("Player");
        private HealthSystem healtSystem;
        //private HealthSystemStruct healthSystem;

        [SetUp]
        public void SetTests()
        {
            health.value = 100;
            if (healtSystem == null)
                healtSystem = go.AddComponent<HealthSystem>();
        }

        [Test]
        public void _0_healthSystem_get_60_health_take_40_damage_to_100_health()
        {
            healtSystem.health = health;
            healtSystem.TakeDamage(40);

            Assert.AreEqual(60, health.value);
        }

        [Test]
        public void _1_healthSystem_get_0_health_take_120_damage_to_100_health()
        {
            healtSystem.health = health;
            healtSystem.TakeDamage(120);

            Assert.AreEqual(0, health.value);
        }

        [Test]
        public void _2_healthSystem_get_100_health_take_40_cure_to_100_health()
        {
            healtSystem.health = health;
            healtSystem.TakeCure(40);

            Assert.AreEqual(100, health.value);
        }
    }
}
