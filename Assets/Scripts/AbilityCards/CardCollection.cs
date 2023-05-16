using System.Collections.Generic;
using UnityEngine;

namespace AbilityCards
{
    [CreateAssetMenu(fileName = "CardCollection", menuName = "ScriptableObjects/CardCollection")]
    public class CardCollection : ScriptableObject
    {
        [SerializeField] private List<CardData> cards;
        private Dictionary<int, CardData> cardDictionary; // Dictionary to store cards by ID

        public List<CardData> Cards => cards;

        private void OnEnable()
        {
            BuildCardDictionary();
        }

        private void BuildCardDictionary()
        {
            cardDictionary = new Dictionary<int, CardData>();
            foreach (CardData card in cards)
            {
                if (!cardDictionary.ContainsKey(card.ID))
                {
                    cardDictionary.Add(card.ID, card);
                }
                else
                {
                    Debug.LogWarning($"Duplicate card ID found: {card.ID}. Ignoring the duplicate entry.");
                }
            }
        }

        public CardData GetCardByID(int id)
        {
            if (cardDictionary.ContainsKey(id))
            {
                return cardDictionary[id];
            }

            Debug.LogWarning($"Card with ID {id} not found in the card collection.");
            return null;
        }
    }
}