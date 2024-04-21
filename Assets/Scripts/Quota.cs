using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quota : MonoBehaviour
{
    private TextMeshProUGUI textQuota;
    public int quota;
    public void ChangeQuota()
    {
        textQuota.text = quota.ToString() + " ���";
    }
    private void Start()
    {
        textQuota = GetComponent<TextMeshProUGUI>();
        ChangeQuota();
    }
}
