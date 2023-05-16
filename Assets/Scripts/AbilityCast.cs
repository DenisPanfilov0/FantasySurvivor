using System.Collections.Generic;
using AbilityCards;
using UnityEngine;

public class AbilityCast : MonoBehaviour
{
    private Dictionary<int, bool> instantiatedPrefabs = new Dictionary<int, bool>();

    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Q))
        // {
        //     InstantiateAbilityCard(0);
        // }
        // if (Input.GetKeyDown(KeyCode.W))
        // {
        //     InstantiateAbilityCard(1);
        // }
        // if (Input.GetKeyDown(KeyCode.E))
        // {
        //     InstantiateAbilityCard(2);
        // }
    }

    public void InstantiateAbilityCard(int cardID)
    {
        CardData cardData = ServiceLocator.Instance.CardCollection.GetCardByID(cardID);
        if (cardData != null)
        {
            if (!instantiatedPrefabs.ContainsKey(cardID) || !instantiatedPrefabs[cardID])
            {
                GameObject abilityCardPrefab = cardData.SkillPrefab;
                if (abilityCardPrefab != null)
                {
                    Instantiate(abilityCardPrefab, new Vector3(1f, 1f, 0f), Quaternion.identity);
                    instantiatedPrefabs[cardID] = true;
                }
            }
        }
        ServiceLocator.Instance.OpenOrCloseUI.CloseAbilityCardsMenu();

    }
    
    
}