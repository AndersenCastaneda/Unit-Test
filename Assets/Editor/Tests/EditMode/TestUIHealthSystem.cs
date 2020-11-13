#if TESTING
#pragma warning disable IDE1006

using NUnit.Framework;
using TestUnity.UISystems;
using UnityEngine;
using UnityEngine.UI;

namespace Tests
{
    public class TestUIHealthSystem
    {

        private readonly IntRefference health = ScriptableObject.CreateInstance<IntRefference>();
        private readonly IntRefference maxHealth = ScriptableObject.CreateInstance<IntRefference>();
        private readonly GameObject go = new GameObject();
        private UIHealth uiHealthSystem;
        private Slider slider;

        [SetUp]
        public void SetTests()
        {

            if (slider == null)
            {
                maxHealth.value = 100;
                slider = go.AddComponent<Slider>();
                uiHealthSystem = go.AddComponent<UIHealth>();
                uiHealthSystem.health = health;
                uiHealthSystem.maxHealth = maxHealth;
                uiHealthSystem.slider = slider;
            }
        }

        [TestCase(45, 100, 45)]
        [TestCase(0, 20, 0)]
        public void Test_UpdateInfo(int currentHealth, int sliderValue, int expected)
        {
            // Arrange
            health.value = currentHealth;
            slider.value = sliderValue;
            uiHealthSystem.InitComponent();

            // Act
            uiHealthSystem.UpdateInfo();

            //Assert
            Assert.AreEqual(0, slider.minValue);
            Assert.AreEqual(maxHealth.value, slider.maxValue);
            Assert.AreEqual(expected, uiHealthSystem.slider.value);
        }
    }
}
#endif
