using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusTimer : MonoBehaviour {

    private Text bonusText;

    public void Start()
    {
        bonusText = gameObject.GetComponent<Text>();
    }

    public void AddBonusTimerText(string bonusName)
    {
        bonusText.text = bonusName;
        Invoke("Clear", 1.0f);
        Debug.Log(bonusName);
    }

    private void Clear()
    {
        bonusText.text = "";
    }
}
