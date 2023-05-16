using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AbilityCards;

public class FillingContentWithCards : MonoBehaviour
{
    public Transform contentContainer;
    public int maxCardCount = 3;

    private void Start()
    {
        FillScrollViewWithRandomCards();
    }

    public void FillScrollViewWithRandomCards()
    {
        //ClearScrollView();

        int cardCount = Mathf.Min(maxCardCount, ServiceLocator.Instance.CardCollection.Cards.Count);
        var uniqueCardIDs = new HashSet<int>();

        for (int i = 0; i < cardCount; i++)
        {
            CardData randomCard = GetRandomUniqueCard(uniqueCardIDs);
            if (randomCard != null)
            {
                GameObject cardObject = Instantiate(randomCard.VisualCardPrefab, contentContainer);
                // Set the card's data or display it in the UI as desired
                CardButton cardButton = cardObject.GetComponent<CardButton>();
                if (cardButton != null)
                {
                    cardButton.Initialize(randomCard.ID);
                }
            }
        }
    }
    
    private CardData GetRandomUniqueCard(HashSet<int> uniqueCardIDs)
    {
        while (uniqueCardIDs.Count < ServiceLocator.Instance.CardCollection.Cards.Count)
        {
            int randomIndex = Random.Range(0, ServiceLocator.Instance.CardCollection.Cards.Count);
            CardData randomCard = ServiceLocator.Instance.CardCollection.Cards[randomIndex];
            
            if (!uniqueCardIDs.Contains(randomCard.ID))
            {
                uniqueCardIDs.Add(randomCard.ID);
                return randomCard;
            }
        }

        return null;
    }

    // private void ClearScrollView()
    // {
    //     foreach (Transform child in contentContainer)
    //     {
    //         Destroy(child.gameObject);
    //     }
    // }
}