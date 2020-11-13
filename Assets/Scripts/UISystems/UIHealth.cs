#pragma warning disable 0649

using UnityEngine;
using UnityEngine.UI;

namespace TestUnity.UISystems
{
    public sealed class UIHealth : MonoBehaviour
    {
#if TESTING
        public Slider slider;
        public IntRefference health;
        public IntRefference maxHealth;
#else
        [SerializeField] private Slider slider;
        [SerializeField] private IntRefference health;
        [SerializeField] private IntRefference maxHealth;
#endif

        private void Awake() => InitComponent();

        private void Update() => UpdateInfo();

        public void InitComponent()
        {
            if (slider == null)
                slider = GetComponent<Slider>();

            slider.minValue = 0;
            slider.maxValue = maxHealth.value;
            slider.value = health.value;
        }

        public void UpdateInfo() => slider.value = health.value;
    }
}
