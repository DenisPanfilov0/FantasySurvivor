using System;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    // Singleton instance
    private static HeroController instance;

    // Public properties
    public int MaxHealth { get; set; }
    public int CurrentHealth { get; set; }
    public int Damage { get; set; }
    public float Balance { get; set; }

    // Private constructor to prevent instantiation
    private HeroController() { }

    // Static method to get the singleton instance
    public static HeroController Instance
    {
        get
        {
            if (instance == null)
            {
                // Create a new GameObject to hold the GameManager if it doesn't exist
                GameObject singletonObject = new GameObject("HeroController");
                instance = singletonObject.AddComponent<HeroController>();
            }
            return instance;
        }
    }

    // Initialize the GameManager
    public void Initialize()
    {
        // Set initial values
        MaxHealth = 100;
        Damage = 10;
        Balance = 0.0f;
    }

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }
}