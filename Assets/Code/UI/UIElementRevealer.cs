using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


//Keeps the upgrade buttons in a list that gets checked everytime the player
//gains gold or upgrades to determine if a hidden button can be revealed. 

public class UIElementRevealer : MonoBehaviour
{
    public static UIElementRevealer instance;
    [System.Serializable]

    //Local class
    class RevealableEntry
    {
        public int threshold; //e.g. gold amount, level.
        public CanvasGroup objectToReveal;
    }

    [SerializeField]
    List<RevealableEntry> totalGoldUnlocks;
    [SerializeField]
    List<RevealableEntry> clickLevelUnlocks;
    [SerializeField]
    List<RevealableEntry> automationLevelUnlocks;

    void Awake()
    {
        instance = this;
        
    }

    void Start()
    {
        //Hide all buttons on gamestart
        foreach (var item in totalGoldUnlocks)
            item.objectToReveal.alpha = 0;
        foreach (var item in clickLevelUnlocks)
            item.objectToReveal.alpha = 0;
        foreach (var item in automationLevelUnlocks)
            item.objectToReveal.alpha = 0;
    }

    public void CheckUnlockable_TotalGold(int gold)
    {
        //Check the first object in the list to see if unlockable
        if (totalGoldUnlocks.Count > 0 && gold >= totalGoldUnlocks[0].threshold)
        {
            totalGoldUnlocks[0].objectToReveal.alpha = 1;
            totalGoldUnlocks.RemoveAt(0);
        }
    }

    public void CheckUnlockable_ClickLevel(int level)
    {
        if (clickLevelUnlocks.Count > 0 && level >= clickLevelUnlocks[0].threshold)
        {
            clickLevelUnlocks[0].objectToReveal.alpha = 1;
            clickLevelUnlocks.RemoveAt(0);
        }
    }

    public void CheckUnlockable_AutomationLevel(int level)
    {
        if (automationLevelUnlocks.Count > 0 && level >= automationLevelUnlocks[0].threshold)
        {
            automationLevelUnlocks[0].objectToReveal.alpha = 1;
            automationLevelUnlocks.RemoveAt(0);
        }
    }
}