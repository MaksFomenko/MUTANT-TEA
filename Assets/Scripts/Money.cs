using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Money : MonoBehaviour
{
    private TextMeshProUGUI textMoney;
    public int money;
    private void Start()
    {
        money = 10;
        textMoney = GetComponent<TextMeshProUGUI>();
        RestartMoney();
    }

    public void RestartMoney()
    {
        textMoney.text = money.ToString() + " душ";
    }
}
