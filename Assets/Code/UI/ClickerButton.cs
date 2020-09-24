using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

//Thsi is the main clicking button that generates coin per click
public class ClickerButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Text gainText;
    GameManager sceneManager;

    void Start()
    {
        sceneManager = GameManager.instance;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        sceneManager.ManualClick();
    }

    //Allow changing of the display text
    public void SetTextAmount (int amount)
    {
        gainText.text = amount.ToString();
    }
}