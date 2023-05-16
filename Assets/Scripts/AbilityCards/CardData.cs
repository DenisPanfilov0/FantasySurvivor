using UnityEngine;

namespace AbilityCards
{
    [CreateAssetMenu(fileName = "CardData", menuName = "ScriptableObjects/CardData")]
    public class CardData : ScriptableObject
    {
        [SerializeField] private int _id;
        [SerializeField] private string _description;
        [SerializeField] private string _cardName;
        [SerializeField] private int _currentVisualLevel;
        [SerializeField] private int _currentSkillLevel;
        [SerializeField] private GameObject _abilityPrefab;
        [SerializeField] private GameObject _visualCardPrefab;

        public int ID => _id;
        public string Description => _description;
        public string CardName => _cardName;
        public int CurrentVisualLevel => _currentVisualLevel;
        public int CurrentSkillLevel => _currentSkillLevel;
        public GameObject SkillPrefab => _abilityPrefab;
        public GameObject VisualCardPrefab => _visualCardPrefab;
    }
}