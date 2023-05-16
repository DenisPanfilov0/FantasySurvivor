using UnityEngine;

namespace DefaultNamespace
{
    public class OpenOrCloseUI : MonoBehaviour
    {
        [SerializeField] private GameObject _menuAbilityCards;

        public void CloseAbilityCardsMenu()
        {
            _menuAbilityCards.SetActive(false);
        }       
        
        public void OpenAbilityCardsMenu()
        {
            _menuAbilityCards.SetActive(true);
        }
    }
}