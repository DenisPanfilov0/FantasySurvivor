using System;
using UnityEngine;

namespace DefaultNamespace.Enemy
{
    public class BasicEnemy : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] private float _speed;
        [SerializeField] private int _damage;
        [SerializeField] private int _expDrop;
        [SerializeField] private Transform _target;

        private void Attack()
        {
            if (ServiceLocator.Instance.HeroController.CurrentHealth > 0)
            {
                ServiceLocator.Instance.HeroController.CurrentHealth -= _damage;
                ServiceLocator.Instance.HealthBarSlider.UpdateHealthBar(); 
            }
            DieHero();

        }

        private void TakeDamage()
        {
            if (_health > 0)
            {
                _health -= _damage;
            }
            DieEnemy();
        }

        private void DieEnemy()
        {
            Debug.Log("Вы убили врага ура!!!");
        }

        private void DieHero()
        {
            Debug.Log("Вас убили");
        }

        private void Update()
        {
            if (_target != null)
            {
                // Calculate the direction to the target
                Vector3 direction = _target.position - transform.position;
                direction.Normalize();

                // Move towards the target
                transform.Translate(direction * _speed * Time.deltaTime);
            }
        }
    }
}