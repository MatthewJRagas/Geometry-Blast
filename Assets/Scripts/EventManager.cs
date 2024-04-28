using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;
    public static float gameTime;

    public static int enemyMinHealth;
    public static int enemyMaxHealth;


    public delegate void ExperienceChangeHandler(int amount);
    public event ExperienceChangeHandler OnExperienceChange;

    //singleton check
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    private void Start()
    {
        enemyMinHealth = 5;
        enemyMaxHealth = 15;
    }
    private void Update()
    {
        gameTime += Time.deltaTime;

        if (gameTime >= 60.0f)
        {
            IncrementHealthVlaues();
        }
    }

    //add experience to the character
    public void AddExperience(int amount)
    {
        OnExperienceChange?.Invoke(amount);
    }

    private void IncrementHealthVlaues()
    {
        enemyMinHealth += 5;
        enemyMaxHealth += 5;
        gameTime = 0;
    }
}