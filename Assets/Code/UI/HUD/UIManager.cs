using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Handles the displaying of HUD texts
public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("Texts")]
    [SerializeField] Text totalGold;
    [SerializeField] Text goldPerSec;

    [Header("Buttons")]
    [SerializeField] ClickerButton clickerButton;

    void Awake()
    {
        instance = this;
    }

    #region Set HUD texts
    public void SetTotalGold(int amount)
    {
        totalGold.text = amount.ToString();
    }

    public void SetGoldPerClick(int amount)
    {
        clickerButton.SetTextAmount(amount);
    }

    public void SetGoldPerSec(int amount)
    {
        goldPerSec.text = amount.ToString();
    }
    #endregion
}