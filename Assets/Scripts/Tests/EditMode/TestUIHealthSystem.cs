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
        private Slider slider;
        private UIHealth uiHealthSystem;

        [SetUp]
        public void SetTests()
        {
            health.value = 100;
            maxHealth.value = 100;

            if (slider == null)
            {
                slider = go.AddComponent<Slider>();
                uiHealthSystem = go.AddComponent<UIHealth>();
                uiHealthSystem.health = health;
                uiHealthSystem.maxHealth = maxHealth;
                uiHealthSystem.slider = slider;
            }
        }

        [Test]
        public void _0_Test_UpdateInfo()
        {
            health.value = 34;
            uiHealthSystem.InitComponent();
            uiHealthSystem.UpdateInfo();

            Assert.AreEqual(34, uiHealthSystem.slider.value);
        }
    }
}
#endif
