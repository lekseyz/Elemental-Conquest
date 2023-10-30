using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIhealth : MonoBehaviour
{
    [SerializeField] private Destructible destructible;
    [SerializeField] private Image image;

    private void Start()
    {
        destructible.ChangeHP.AddListener(OnChangeHitPoints);
    }
    private void OnDestroy()
    {
        destructible.ChangeHP.RemoveListener(OnChangeHitPoints);
    }
    private void OnChangeHitPoints()
    {
        if (image.fillAmount > 0)
        image.fillAmount =(float)destructible.GetHitPoints() / (float)destructible.GetMaxHitPoints();
    }

}
