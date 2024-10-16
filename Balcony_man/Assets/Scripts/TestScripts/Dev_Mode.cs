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

    // Start is called before the first frame update
    void Start()
    {
        Intilization();
        AddListenerButtons();
    }

    // Update is called once per frame
    void Update()
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
        for (int i = 0; i < SpawnPoint.Count; i++) 
        {
            SpawnPoint[i] = GetComponent<Transform>();
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
        if (!isOpen)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isOpen = !isOpen;
            Cursor.visible = isOpen;
            Cursor.lockState = CursorLockMode.None;
        }
        Panel_Dev.SetActive(isOpen);
    }

    private void OnTeleportHouse()
    {
        Debug.Log("Tp on house");
        Person.transform.localPosition = SpawnPoint[0].transform.position;
    }

    private void OnTeleportStreet()
    {
        Debug.Log("Tp on Street");
        Person.transform.localPosition = SpawnPoint[1].transform.position;
    }
}
