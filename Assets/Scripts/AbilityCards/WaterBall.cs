using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace.AbilityCards
{
    public class WaterBall : MonoBehaviour, IAbilityCaster
    {
        
        [SerializeField] private GameObject _waterballPrefab;
        [SerializeField] private float _waterballDistance;
        [SerializeField] private float _waterballSpeed;
        [SerializeField] private float _waterballInterval;
        [SerializeField] private float _waterballDamage;
        private InputController inputController;
        private float timer;
        
        
        private void Start()
        {
            inputController = FindObjectOfType<InputController>();
        }
        
        private void Update()
        {
            timer += Time.deltaTime;
            if (timer >= _waterballInterval)
            {
                CastAbility();
                timer = 0f;
            }
        }
        
        public void CastAbility()
        {
            Vector2 DirectionCast = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            GameObject waterball = Instantiate(_waterballPrefab, inputController.transform.position, Quaternion.identity);
            Rigidbody2D rb = waterball.GetComponent<Rigidbody2D>();
            rb.velocity = DirectionCast * _waterballSpeed;

            float angle = Mathf.Atan2(DirectionCast.y, DirectionCast.x) * Mathf.Rad2Deg + 180f;
            waterball.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            
            Destroy(waterball, _waterballDistance / _waterballSpeed);


        }
    }
}