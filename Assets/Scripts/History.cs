using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class History : MonoBehaviour
{
    [System.Serializable]
    public class Item
    {
        public string MASSAGE;
        public int ID;
        public int STRENG;
    }

    private static History s_instance;
    public static History Instance
    {
        get
        {
            if (s_instance == null)
            {
                s_instance = FindObjectOfType<History>();
                DontDestroyOnLoad(s_instance.gameObject);
            }
            return s_instance;
        }
    }

    public List<Item> startHis = new List<Item>();
    public List<Item> midHis = new List<Item>();
    public List<Item> endHis = new List<Item>();
    public List<int> usedItems = new List<int>();

    public List<Item> Generate()
    {
        List<Item> history = new List<Item>();

        startHis.Shuffle();
        foreach (Item item in startHis) 
        {
            if (!usedItems.Contains(item.ID))
            {
                usedItems.Add(item.ID);
                history.Add(item);
                break;
            }
        }
        midHis.Shuffle();
        foreach (Item item in midHis)
        {
            if (!usedItems.Contains(item.ID))
            {
                usedItems.Add(item.ID);
                history.Add(item);
                break;
            }
        }
        endHis.Shuffle();
        foreach (Item item in endHis)
        {
            if (!usedItems.Contains(item.ID))
            {
                usedItems.Add(item.ID);
                history.Add(item);
                break;
            }
        }

        return history;
    }
}
