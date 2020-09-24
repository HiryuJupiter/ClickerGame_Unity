using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class AutomationUpgradeButton : UpgradeButton
{
    public AutomationTypes type;

    protected override void Awake()
    {
        //Convert the enum type to a string that's used for saving/loading
        stringKey = EnumUtil.GetName<AutomationTypes>(type);
        incrementSuffix = "/sec";
        base.Awake();
    }
    protected override void IncrementSceneStats()
    {
        sceneManager.IncreaseGoldPerSec(currentGain - previousGain);
    }
}
