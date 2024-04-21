using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VisualHistory : MonoBehaviour
{
    List<History.Item> history = new();
    [SerializeField] private string[] historyText;
    [SerializeField] private TextMeshProUGUI[] Texts;
    public int[] streng;
    [SerializeField] private Slider slider;
    [SerializeField] private GeneratePeople gPeople;
    [SerializeField] private SpawnAnimation[] spawn;

    public void Visual()
    {
        gPeople.Generate();
        spawn = FindObjectsOfType<SpawnAnimation>();

        foreach (var item in spawn) 
        {
            item.SpawnAnim();
        }

        for (int i = 0; i < 2; i++)
        {
            history = History.Instance.Generate();
            string massage = "";
            int _streng = 0;
            foreach (History.Item item in history)
            {
                massage += item.MASSAGE;
                _streng += item.STRENG;
            }
            historyText[i] = massage;
            streng[i] = _streng;
            Texts[i].text = historyText[i];
            Debug.Log(streng[i] + " STRENG " + i + " TEXT");
        }
    }

    void Start()
    {
        Visual();
    }
}
