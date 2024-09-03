using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] Event _evenet;

    public void Start()
    {
        _evenet.Start();
    }
    private void Update()
    {
        _evenet.OnCurrentEvent();
    }
    public void GetEvent(){

    }

    public void SetEvent()
    {

    }
}

[System.Serializable]
public class Event
{
    public string[] names;


    public GameObject[] TriggerForLaunchEvent;
    public int Current;
    public void Start()
    {
        for(int i = 0; i < TriggerForLaunchEvent.Length; i++)
        {
            TriggerForLaunchEvent[i].SetActive(true);
        }
    }

    public void OnCurrentEvent()
    {
        Debug.Log("События: " + names[Current] + " Триггеров: " + TriggerForLaunchEvent[Current]);

        if(Current >= 0 && Current < names.Length - 1)
        {
            names[Current] = names[Current];
        }
        else{

            Current = names.Length;
        }
        //Создаем коллайдер чтобы проверить с каким именно он сталкунлся для запуска триггера
        Collider[] hitCollider = Physics.OverlapBox(TriggerForLaunchEvent[Current].transform.position, TriggerForLaunchEvent[Current].transform.localScale / 2);

        if(hitCollider[Current].CompareTag("Player"))
        {
            TriggerForLaunchEvent[Current].gameObject.SetActive(false);
            Debug.Log(hitCollider[Current].ToString() + ":Включен Триггер" );
        }
    }
}
