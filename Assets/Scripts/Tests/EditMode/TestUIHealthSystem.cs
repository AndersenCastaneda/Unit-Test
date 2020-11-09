using NUnit.Framework;
using TestUnity.UISystems;
using UnityEngine;
using UnityEngine.UI;

namespace Tests
{
    public class TestUIHealthSystem
    {
#pragma warning disable

        private readonly IntRefference health = ScriptableObject.CreateInstance<IntRefference>();
        private readonly GameObject go = new GameObject("Player");
        private Slider slider;
        private UIHealthSystem uiHealthSystem;

        [SetUp]
        public void SetTests()
        {
            health.value = 100;
            if (slider == null)
            {
                slider = go.AddComponent<Slider>();
                uiHealthSystem = go.AddComponent<UIHealthSystem>();
                uiHealthSystem.health = health;
                uiHealthSystem.slider = slider;
            }
        }

        [Test]
        public void _0_healthSystem_get_34_health()
        {
            health.value = 34;
            uiHealthSystem.SetRange();
            uiHealthSystem.UpdateInfo();

            Assert.AreEqual(34, uiHealthSystem.slider.value);
        }
    }
}
