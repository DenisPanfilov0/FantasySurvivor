using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace DefaultNamespace.AbilityCards
{
    public class ElectricBall : MonoBehaviour, IAbilityCaster
    {
        [SerializeField] private GameObject _electricballPrefab;
        [SerializeField] private float _electricballDistance;
        [SerializeField] private float _electricballSpeed;
        [SerializeField] private float _electricballInterval;
        [SerializeField] private float _electricballDamage;
        private InputController inputController;
        private float timer;
        
        
        private void Start()
        {
            inputController = FindObjectOfType<InputController>();
        }
        
        private void Update()
        {
            timer += Time.deltaTime;
            if (timer >= _electricballInterval)
            {
                CastAbility();
                timer = 0f;
            }
        }
        
        public void CastAbility()
        {
            Vector2 DirectionCast = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            GameObject electricball = Instantiate(_electricballPrefab, inputController.transform.position, Quaternion.identity);
            //GameObject electricball = Instantiate(gameObject, _heroInputController.transform.position, Quaternion.identity);
            Rigidbody2D rb = electricball.GetComponent<Rigidbody2D>();
            rb.velocity = DirectionCast * _electricballSpeed;

            float angle = Mathf.Atan2(DirectionCast.y, DirectionCast.x) * Mathf.Rad2Deg + 180f;
            electricball.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            
            Destroy(electricball, _electricballDistance / _electricballSpeed);
        }
    }
}