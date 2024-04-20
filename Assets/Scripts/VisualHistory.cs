using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VisualHistory : MonoBehaviour
{
    List<History.Item> history = new();
    [SerializeField] private string[] historyText;
    [SerializeField] private TextMeshProUGUI[] Texts;

    void Visual()
    {
        for (int i = 0; i < 2; i++)
        {
            history = History.Instance.Generate();
            string massage = "";
            foreach (History.Item item in history)
            {
                massage += item.MASSAGE;
            }
            historyText[i] = massage;
            Texts[i].text = historyText[i];
        }
    }

    void Start()
    {
        Visual();
    }
}
