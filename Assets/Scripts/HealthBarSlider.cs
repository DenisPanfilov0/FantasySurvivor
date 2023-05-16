using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class HealthBarSlider : MonoBehaviour
    {
        [SerializeField] private Slider _healthSlider;
        private int _maxHeath = ServiceLocator.Instance.HeroController.MaxHealth;
        private int _currentHeath = ServiceLocator.Instance.HeroController.CurrentHealth;

        private void Start()
        {
            _healthSlider.maxValue = _maxHeath;
            _healthSlider.value = _maxHeath;
        }

        public void UpdateHealthBar()
        {
            _healthSlider.value = _currentHeath;
        }
    }
}