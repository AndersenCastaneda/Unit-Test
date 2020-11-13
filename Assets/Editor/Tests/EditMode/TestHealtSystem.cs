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
        private readonly HealthSystem healthSystem = new GameObject().AddComponent<HealthSystem>();

        [SetUp]
        public void SetTests()
        {
            if (healthSystem.health == null)
            {
                maxHealth.value = 100;
                healthSystem.health = health;
                healthSystem.maxHealth = maxHealth;
            }
        }

        [TestCase(0, 20, 0)]
        [TestCase(40, 40, 80)]
        [TestCase(90, 40, 100)]
        public void Test_0_take_cure_and_health_cannot_exceed_maximuz_health(int currentHealth, int cure, int expected)
        {
            health.value = currentHealth;               // Arrange
            healthSystem.TakeCure(cure);                // Act
            Assert.AreEqual(expected, health.value);    // Assert
        }

        [TestCase(80, 20, 60)]
        [TestCase(10, 20, 0)]
        public void Test_1_take_damage_and_health_cannot_go_negative(int currentHealth, int damage, int expected)
        {
            health.value = currentHealth;               // Arrange
            healthSystem.TakeDamage(damage);            // Act
            Assert.AreEqual(expected, health.value);    //Assert
        }
    }
}
#endif
