using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class GeneratePeople : MonoBehaviour
{
    [SerializeField] private GameObject[] heads;
    [SerializeField] private GameObject[] bodys;
    [SerializeField] private GameObject[] people;

    public void Generate()
    {
        for (int i = 0; i < 2; i++) 
        {
            GameObject head = Instantiate(heads[Random.Range(0, heads.Length)]);
            head.transform.SetParent(people[i].transform);
            GameObject body = Instantiate(bodys[Random.Range(0, bodys.Length)]);
            body.transform.SetParent(people[i].transform);
            head.transform.position = new Vector3(people[i].transform.position.x, people[i].transform.position.y+4.2f, people[i].transform.position.z);
            body.transform.position = people[i].transform.position;
        }
    }
}
