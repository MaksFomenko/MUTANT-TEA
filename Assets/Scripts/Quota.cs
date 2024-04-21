using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quota : MonoBehaviour
{
    private TextMeshProUGUI textQuota;
    [SerializeField] private int quota;
    public void ChangeQuota()
    {
        textQuota.text = quota.ToString() + " душ";
    }
    private void Start()
    {
        textQuota = GetComponent<TextMeshProUGUI>();
        ChangeQuota();
    }
}
