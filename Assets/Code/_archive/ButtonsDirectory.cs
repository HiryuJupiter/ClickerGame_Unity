using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class ButtonsDirectory_ : MonoBehaviour
{
    //We initialize them here, as on the Awake() frame, we want Buttons to register
    //themselves, and on Start() frame, we want to load game data and assign values 
    //to the registered Buttons
    Dictionary<AutomationTypes, AutomationUpgradeButton> automationUpgradeButtons = new Dictionary<AutomationTypes, AutomationUpgradeButton>();
    Dictionary<ManualUpgradeTypes, ManualUpgradeButton> manualUpgradeButton = new Dictionary<ManualUpgradeTypes, ManualUpgradeButton>();

    GameManager sceneManager;


    void Start()
    {
        sceneManager = GameManager.instance;
    }

    public void RegisterManualButton(ManualUpgradeTypes types, ManualUpgradeButton button)
    {
        manualUpgradeButton.Add(types, button);

    }
    public void RegisterAutomantionButton (AutomationTypes types, AutomationUpgradeButton button)
    {
        automationUpgradeButtons.Add(types, button);
    }
}



