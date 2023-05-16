using AbilityCards;
using DefaultNamespace;
using DefaultNamespace.Enemy;
using UnityEngine;
using UnityEngine.Serialization;

public class ServiceLocator : MonoBehaviour
{
    public static ServiceLocator Instance { get; private set; }

    // Reference to the CardCollection
    //public CardCollection CardCollection { get; private set; }
    
    [SerializeField] private CardCollection cardCollection;
    [SerializeField] private AbilityCast abilityCast;
    [SerializeField] private OpenOrCloseUI openOrCloseUI;
    [SerializeField] private HeroController heroController;
    [SerializeField] private BasicEnemy basicEnemy;
    [SerializeField] private HealthBarSlider healthBarSlider;

    // Reference to the CardCollection
    public CardCollection CardCollection => cardCollection;
    public AbilityCast AbilityCast => abilityCast;
    public OpenOrCloseUI OpenOrCloseUI => openOrCloseUI;
    public HeroController HeroController => heroController;
    public BasicEnemy BasicEnemy => basicEnemy;
    public HealthBarSlider HealthBarSlider => healthBarSlider;

    private void Awake()
    {
        // Initialize the singleton instance
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Load the CardCollection from a ScriptableObject
        //CardCollection = Resources.Load<CardCollection>("CardCollection");
    }
}