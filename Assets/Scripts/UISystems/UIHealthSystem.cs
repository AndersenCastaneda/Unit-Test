using UnityEngine;
using UnityEngine.UI;

namespace TestUnity.UISystems
{
    public sealed class UIHealthSystem : MonoBehaviour
    {
//#pragma warning disable 0649
//        [SerializeField] private Slider slider;
//        [SerializeField] private IntRefference health;
//#pragma warning restore 0649

        public Slider slider;
        public IntRefference health;

        private void Awake()
        {
            slider = GetComponent<Slider>();
            SetRange();
        }

        private void Start() => slider.value = health.value;

        public void SetRange()
        {
            slider.minValue = 0;
            slider.maxValue = 100;
        }

        public void UpdateInfo() => slider.value = health.value;
    }
}
