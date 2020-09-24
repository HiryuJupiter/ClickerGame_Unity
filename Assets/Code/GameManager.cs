using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Statics
    public static event Action OnSaving = () => { };
    public static event Action OnLoading = () => { };
    public static GameManager instance;

    //References
    UIManager uiManager;
    UIElementRevealer elementRevealer;

    //Properties
    public int TotalGold { get; private set; }
    public int TotalGoldPerClick { get; private set; } = 1;
    public int TotalGoldPerSec { get; private set; }

    #region Mono
    void Awake()
    {
        instance = this;
        StartCoroutine(IncrementPassiveGold());
    }

    void Start()
    {
        uiManager = UIManager.instance;
        elementRevealer = UIElementRevealer.instance;

        Load();
        UpdateHUD_GoldPerClick();
        UpdateHUD_GoldPerSec();
        UpdateHUD_TotalGold();
    }
    #endregion

    #region Public - resource 
    public void IncreaseGoldPerSec (int amount)
    {
        //elementRevealer.CheckUnlockable_AutomationLevel(TotalGold);

        TotalGoldPerSec += amount;
        UpdateHUD_GoldPerSec();
    }

    public void IncreaseClickPower(int amount)
    {
        //elementRevealer.CheckUnlockable_ClickLevel(TotalGold);

        TotalGoldPerClick += amount;
        UpdateHUD_GoldPerClick();
    }

    public bool TryReduceGold (int cost)
    {
        if (TotalGold > cost)
        {
            TotalGold -= cost;
            UpdateHUD_TotalGold();
            return true;
        }
        return false;
    }

    public void ManualClick ()
    {

        IncreaseTotalGold(TotalGoldPerClick);
        UpdateHUD_TotalGold();
    }

    public void IncreaseTotalGold(int amount)
    {
        elementRevealer.CheckUnlockable_TotalGold(TotalGold);

        TotalGold += amount;
        UpdateHUD_TotalGold();
    }
    #endregion

    #region Public - save load
    public void Save() => OnSaving?.Invoke();
    public void Load() => OnLoading?.Invoke();
    #endregion

    #region Increment
    IEnumerator IncrementPassiveGold()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            IncreaseTotalGold(TotalGoldPerSec);
        }
    }

    void UpdateHUD_TotalGold ()
    {
        Debug.Log("uiManager " + uiManager);
        uiManager.TypeTotalGold(TotalGold);
    }

    void UpdateHUD_GoldPerClick()
    {
        uiManager.TypeGoldPerClick(TotalGoldPerClick);
    }

    void UpdateHUD_GoldPerSec()
    {
        uiManager.TypeGoldPerSec(TotalGoldPerSec);
    }
    #endregion
}