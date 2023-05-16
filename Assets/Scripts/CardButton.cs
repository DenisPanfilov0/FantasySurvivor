using UnityEngine;
using UnityEngine.UI;

public class CardButton : MonoBehaviour
{
    public int CardID { get; private set; }

    public void Initialize(int cardID)
    {
        CardID = cardID;
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
    }

    private void OnButtonClick()
    {
        Debug.Log("Card clicked. ID: " + CardID);

        // You can perform any actions or pass the card ID to other methods as needed
        // AbilityCast abilityCast = FindObjectOfType<AbilityCast>();
        // if (abilityCast != null)
        // {
        //     ServiceLocator.Instance.AbilityCast.InstantiateAbilityCard(CardID);
        // }
        ServiceLocator.Instance.AbilityCast.InstantiateAbilityCard(CardID);

    }
}