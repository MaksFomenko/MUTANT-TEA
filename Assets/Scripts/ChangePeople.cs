using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangePeople : MonoBehaviour
{
    [SerializeField] private Vector3 newSize = new Vector3();
    [SerializeField] private Vector3 standartSize = new Vector3();
    [SerializeField] private Vector3 centerPos = new Vector3();
    [SerializeField] private Vector3 centerTextPos = new Vector3();
    private GameObject lastHit;
    [SerializeField] private GameObject[] allMan;
    [SerializeField] private TextMeshProUGUI[] allText;
    [SerializeField] private GameObject strenge;
    [SerializeField] private VisualHistory vHistory;
    [SerializeField] private GameObject buttonCheckStrenge;
    [SerializeField] private Money _money;
    [SerializeField] private int currentID;
    [SerializeField] private GameObject buttonDeathCard;
    [SerializeField] private bool onObj = true;
    [SerializeField] private TextMeshProUGUI textCard;
    [SerializeField] private Animator cameraAnim;
    [SerializeField] private GameObject hells;
    int i = 0;
    private int temp = 0;

    public void FindPeople()
    {
        //allMan = GameObject.FindGameObjectsWithTag("People");
    }

    void Start()
    {
        FindPeople();
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.collider.gameObject;
            if (lastHit != hitObject && lastHit != null)
            {
                lastHit.transform.localScale = standartSize;
            }
            if (hitObject.CompareTag("People") && allMan.Length != 1 && onObj)
            {
                currentID = hitObject.GetComponent<PeopleID>().ID;
                hitObject.transform.localScale = newSize;
                lastHit = hitObject;
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    i = 0;
                    if (currentID == 0)                        temp = 1;
                    if (currentID == 1)                        temp = 0;

                    if (vHistory.streng[currentID] >= vHistory.streng[temp])
                    {
                        hitObject.transform.position = centerPos;
                        FindPeople();
                        onObj = false;
                        foreach (GameObject obj in allMan)
                        {
                            if (obj != hitObject)
                            {
                                DestroyAllChildren(obj);
                                obj.SetActive(false);
                                allText[i].text = "";

                                strenge.SetActive(true);
                            }
                            else if(obj == hitObject)
                            {
                                Debug.Log(currentID);
                                allText[currentID].alignment = TextAlignmentOptions.Center;
                                allText[currentID].GetComponent<Animator>().SetBool("isExit", false);
                                allText[currentID].GetComponent<Animator>().SetBool("isChange", true);
                                strenge.SetActive(true);
                                strenge.GetComponent<Animator>().SetBool("isClose", false);
                                strenge.GetComponent<Animator>().SetBool("isOpen", true);
                                allMan[currentID].GetComponent<Animator>().SetBool("isSpawn", false);
                                allMan[currentID].GetComponent<Animator>().SetBool("isChange", true);
                                buttonCheckStrenge.SetActive(true);
                            }
                            i++;
                        }
                    }
                    else
                    {
                        Mistake();
                    }

                }
            }
        }
    }

    void Mistake()
    {
        _money.money -= 1;
        _money.RestartMoney();
        buttonCheckStrenge.SetActive(false);
        strenge.SetActive(false);
        hells.SetActive(false);
        for (int j = 0; j < allMan.Length; j++)
        {
            if (allMan[j] != null)
            {
                DestroyAllChildren(allMan[j]);
                allMan[j].SetActive(true);
                allText[j].text = "";
                allText[j].GetComponent<Animator>().SetBool("isChange", false);
                allText[j].GetComponent<Animator>().SetBool("isExit", true);
            }
        }
        vHistory.Visual();
        onObj = true;
        FindPeople();
    }
    public void CheckCorrectStrenge()
    {
        int tempStrenge = Convert.ToInt32(strenge.GetComponent<Slider>().value);
        Debug.Log(currentID + " = i");
        Debug.Log(tempStrenge + " = tempstrenge");
        Debug.Log(vHistory.streng[currentID] + " = streng[i]");

        if (tempStrenge == vHistory.streng[currentID] || tempStrenge == vHistory.streng[currentID] - 1 || tempStrenge == vHistory.streng[currentID] + 1)
        {
            buttonDeathCard.SetActive(true);
            buttonCheckStrenge.SetActive(false);
            strenge.GetComponent<Animator>().SetBool("isOpen", false);
            strenge.GetComponent<Animator>().SetBool("isClose", true);
        }
        else
            Mistake();
    }

    public void ChangeCard()
    {
        StartCoroutine(EndCard());
        int randCard = UnityEngine.Random.Range(0, 3);
        textCard.gameObject.SetActive(true);
        if(randCard == 0) // �������
        {
            _money.money += 1;
            textCard.text = "�� ���P��!" +
                "+1 ���";
        }
        if (randCard == 1) // ������
        {
            textCard.text = "�P�HE���" +
                "+0 ���";
        }
        if (randCard == 2) // ������
        {
            _money.money -= 1;
            textCard.text = "�� �P��P��!" +
                "-1 ���";
        }
        _money.RestartMoney();
        buttonDeathCard.SetActive(false);
    }

    void DestroyAllChildren(GameObject parent)
    {
        for (int i = parent.transform.childCount - 1; i >= 0; i--)
        {
            GameObject child = parent.transform.GetChild(i).gameObject;
            DestroyImmediate(child);
        }
    }
    private IEnumerator EndCard()
    {
        yield return new WaitForSeconds(3f);
        textCard.gameObject.SetActive(false);
        ChangeMap();
    }
    void ChangeMap()
    {
        cameraAnim = GetComponent<Animator>();
        cameraAnim.SetBool("isEnd", false);
        cameraAnim.SetBool("isStart", true);
        hells.SetActive(true);
    }
    public void FirButton()
    {
        if (vHistory.streng[currentID] < 4)
            Complete();
        else
        {
            cameraAnim = GetComponent<Animator>();
            cameraAnim.SetBool("isStart", false);
            cameraAnim.SetBool("isEnd", true);
            Mistake();
        }
    }
    public void KotlButton()
    {
        if (vHistory.streng[currentID] >= 4 && vHistory.streng[currentID] < 7)
            Complete();
        else
        {
            cameraAnim = GetComponent<Animator>();
            cameraAnim.SetBool("isStart", false);
            cameraAnim.SetBool("isEnd", true);
            Mistake();
        }
    }
    public void RusnyaButton()
    {
        if (vHistory.streng[currentID] >= 7 && vHistory.streng[currentID] <= 10)
            Complete();
        else
        {
            cameraAnim = GetComponent<Animator>();
            cameraAnim.SetBool("isStart", false);
            cameraAnim.SetBool("isEnd", true);
            Mistake();
        }
    }

    void Complete()
    {
        cameraAnim = GetComponent<Animator>();
        cameraAnim.SetBool("isStart", false);
        cameraAnim.SetBool("isEnd", true);
        hells.SetActive(false);
        allMan[currentID].GetComponent<SpawnAnimation>().KillAnim();

        StartCoroutine(WaitNewPeople());
    }
    private IEnumerator WaitNewPeople()
    {
        yield return new WaitForSeconds(3f);
        _money.money += 1;
        _money.RestartMoney();
        buttonCheckStrenge.SetActive(false);
        strenge.SetActive(false);
        hells.SetActive(false);
        for (int j = 0; j < allMan.Length; j++)
        {
            if (allMan[j] != null)
            {
                DestroyAllChildren(allMan[j]);
                allMan[j].SetActive(true);
                allText[j].text = "";
                allText[j].GetComponent<Animator>().SetBool("isChange", false);
                allText[j].GetComponent<Animator>().SetBool("isExit", true);
            }
        }
        vHistory.Visual();
        onObj = true;
        FindPeople();
    }
}
