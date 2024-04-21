using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Money : MonoBehaviour
{
    private TextMeshProUGUI textMoney;
    public int money;
    [SerializeField] private Quota _quota;
    [SerializeField] private GameObject quotaObject;


    private void Start()
    {
        money = 10;
        textMoney = GetComponent<TextMeshProUGUI>();
        RestartMoney();
    }

    public void RestartMoney()
    {
        textMoney.text = money.ToString() + " душ";
        
        if(_quota.quota == money)
        {
            quotaObject.SetActive(true); 
        }


    }
}
