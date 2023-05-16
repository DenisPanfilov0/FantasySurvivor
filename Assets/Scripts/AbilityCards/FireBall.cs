using System;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace.AbilityCards
{
    public class FireBall : MonoBehaviour
    {
        [SerializeField] private GameObject _fireballPrefab;
        [SerializeField] private float _fireballDistance;
        [SerializeField] private float _fireballSpeed;
        [SerializeField] private float _fireballInterval;
        [SerializeField] private float _fireballDamage;
        private InputController inputController;

        private float timer;


        private void Start()
        {
            inputController = FindObjectOfType<InputController>();
        }

        private void Update()
        {
            timer += Time.deltaTime;
            if (timer >= _fireballInterval)
            {
                CastFireball();
                timer = 0f;
            }
        }

        private void CastFireball()
        {
            // Создает FireBall в разном направлении (рандомно)
            //Vector2 DirectionCast = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            
            // Создает FireBall в направлении куда смотрит персонаж
            Vector2 DirectionCast = inputController._lastRaycastDirection;
            GameObject fireball = Instantiate(_fireballPrefab, inputController.transform.position, Quaternion.identity);
            Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
            rb.velocity = DirectionCast * _fireballSpeed;
            
            
            float angle = Mathf.Atan2(DirectionCast.y, DirectionCast.x) * Mathf.Rad2Deg + 180f;
            fireball.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            
            
            Destroy(fireball, _fireballDistance / _fireballSpeed);
        }
    }
}