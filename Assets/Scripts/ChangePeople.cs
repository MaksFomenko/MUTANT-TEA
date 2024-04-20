using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePeople : MonoBehaviour
{
    [SerializeField] private Vector3 newSize = new Vector3();
    [SerializeField] private Vector3 standartSize = new Vector3();
    [SerializeField] private Vector3 centerPos = new Vector3();
    private GameObject lastHit;
    [SerializeField]private GameObject[] allMan;
    [SerializeField] private GameObject strege;

    public void FindPeople()
    {
        allMan = GameObject.FindGameObjectsWithTag("People");
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.collider.gameObject;
            allMan = GameObject.FindGameObjectsWithTag("People");
            if (lastHit != hitObject && lastHit != null)
            {
                lastHit.transform.localScale = standartSize;
            }
            if (hitObject.CompareTag("People") && allMan.Length != 1)
            {
                hitObject.transform.localScale = newSize;
                lastHit = hitObject;
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    hitObject.transform.position = centerPos;
                    FindPeople();
                    foreach (GameObject obj in allMan)
                    {
                        if (obj != hitObject)
                        {
                            Destroy(obj);
                            strege.SetActive(true);
                        }
                    }
                }
            }
        }
    }
}
