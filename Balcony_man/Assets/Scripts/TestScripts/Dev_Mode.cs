using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dev_Mode : MonoBehaviour
{
    public List<Transform> SpawnPoint;

    public GameObject Person;

    public GameObject Panel_Dev;

    private bool isOpen;

    //Button for Teleport
    public Button Tp_street;
    public Button Tp_house;

    public float SmoathTime = 2f;

    private bool CoroutineS = false;

    // Start is called before the first frame update
    private void Start()
    {
        Intilization();
        AddListenerButtons();
    }

    // Update is called once per frame
    public void Update()
    {
        DevMenu();
    }

    private void Intilization()
    {
        if (Panel_Dev != null)
        {
            isOpen = false;
            Panel_Dev.SetActive(isOpen);
        }
        if (Person is null)
        {
            Person = GetComponent<GameObject>();
        }
    }
    private void AddListenerButtons()
    {
        //Teleport
        Tp_street.onClick.AddListener(OnTeleportStreet);
        Tp_house.onClick.AddListener(OnTeleportHouse);
    }

    private void DevMenu()
    {
        //Cheked
        if(!CoroutineS)
        {
            Person.GetComponent<PlayerMovementer>().enabled = true;
        }
        else
        {
            Person.GetComponent<PlayerMovementer>().enabled = false;
        }
        //

        if (!isOpen)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Person.GetComponent<PlayerMovementer>().enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Person.GetComponent<PlayerMovementer>().enabled = false;
            isOpen = !isOpen;
            Cursor.visible = isOpen;
            Cursor.lockState = CursorLockMode.None;
        }
        Panel_Dev.SetActive(isOpen);
    }

    public void OnTeleportHouse()
    {
        StartCoroutine(PlayTpHouse());
    }

    public void OnTeleportStreet()
    {
        StartCoroutine(PlayTpStreet());
    }

    IEnumerator PlayTpStreet()
    {
        CoroutineS = true;
        while (CoroutineS)
        {
            Debug.Log("Tp on Street");
            Vector3 person = Person.transform.position;
            Vector3 spawnPoint1 = SpawnPoint[1].transform.position;
            Person.transform.position = Vector3.Lerp(person, spawnPoint1, SmoathTime * Time.deltaTime);
            yield return new WaitForSeconds(2f);
            CoroutineS = false;
            yield return null;
        }
    }

    IEnumerator PlayTpHouse()
    {
        CoroutineS = true;
        while (CoroutineS)
        {
            Debug.Log("Tp on house");
            Vector3 person = Person.transform.position;
            Vector3 spawnPoint0 = SpawnPoint[0].transform.position;
            Person.transform.position = Vector3.Lerp(person, spawnPoint0, SmoathTime * Time.deltaTime);
            yield return new WaitForSeconds(2f);
            CoroutineS = false;
            yield return null;
        }

    }
}
