using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System.Runtime.InteropServices.ComTypes;
using System;

//The base class for the upgrade buttons
public abstract class UpgradeButton : MonoBehaviour, IPointerClickHandler
{
    [Header("References")] //Reference Ui texts
    [SerializeField] protected Text costText;
    [SerializeField] protected Text nextIncrementText;

    [Header("Stats")] //Specifies the settings
    [SerializeField] protected int startingGain;
    [SerializeField] protected int startingCost;
    [SerializeField] protected int fixedCostIncrease;

    [SerializeField] protected float gainScalar;
    [SerializeField] protected float costScalar;

    protected GameManager sceneManager;

    protected int currentGain;
    protected int currentCost;
    protected int currentLevel;
    protected int nextIncrementAmount; //Difference between next level's gain minus current gain
    protected int previousGain;

    protected string stringKey;
    protected string incrementSuffix;

    protected virtual void Awake()
    {
        //Initialize
        previousGain = 0;
        
        //Subscribes to save / load events in the GameManager
        GameManager.OnLoading += Load;
        GameManager.OnSaving += Save;
    }

    protected virtual void Start()
    {
        sceneManager = GameManager.instance;
    }

    #region Public
    //What happens when the player clicks on the button
    public void OnPointerClick(PointerEventData eventData)
    {
        IncreaseLevel(1);
    }

    void IncreaseLevel(int levelsToAdd)
    {
        //Try to spend gold. If plyer has enough gold, then increase level
        if (sceneManager.TryReduceGold(currentCost))
        {
            currentLevel += levelsToAdd;
            CalculateAndDisplayStats();
            IncrementSceneStats();
        }
    }
    #endregion

    #region Save
    protected void Load()
    {
        currentLevel = PlayerPrefs.GetInt(stringKey, 1);
        CalculateAndDisplayStats();
    }

    protected void Save()
    {
        PlayerPrefs.SetInt(stringKey, currentLevel);
    }
    #endregion

    #region Calculation
    void CalculateAndDisplayStats() //Update the display info on the button
    {
        //Cache previous gain amount
        previousGain = currentGain;

        currentGain = CalculateAmount(startingGain, currentLevel, gainScalar);

        currentCost = CalculateAmount(startingCost, currentLevel, costScalar, fixedCostIncrease);
        costText.text = "Cost: " + currentCost;

        nextIncrementText.text = "+" + currentGain + incrementSuffix;
        
    }

    protected abstract void IncrementSceneStats();

    protected int CalculateAmount(int baseAmount, int clickLevel, float scalar, int fixedIncrease = 0)
    {
        //clickLevel 1 returns 1, 
        //clickLevel 2 returns 2, and then it grows exponentially.
        return baseAmount + fixedCostIncrease * clickLevel + (clickLevel - 1) * (clickLevel - 1) * (int)scalar;
    }
    #endregion
}