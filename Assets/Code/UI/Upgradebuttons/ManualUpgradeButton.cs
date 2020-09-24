using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

//Note 1:Manual buttons are non-automated buttons that you have to click
//Note 2:by using IPointerClickHandler, we don't have to drag and drop anything
//in the inspector
public class ManualUpgradeButton : UpgradeButton, IPointerClickHandler
{
    public ManualUpgradeTypes type;

    protected override void Awake()
    {
        //Convert the enum type to a string that's used for saving/loading
        stringKey = EnumUtil.GetName<ManualUpgradeTypes>(type);
        incrementSuffix = "/click";
        base.Awake();
    }
    protected override void IncrementSceneStats()
    {
        sceneManager.IncreaseClickPower(currentGain - previousGain);
    }
}