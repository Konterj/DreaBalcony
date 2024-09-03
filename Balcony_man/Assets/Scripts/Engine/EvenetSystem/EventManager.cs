using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] Event _evenet;
    [SerializeField] int IndexEvent = 0;
    public void Start()
    {

    }
    private void Update()
    {
        _evenet.OnCurrentEvent(IndexEvent);
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

    void Start()
    {
        for(int i = 0; i < TriggerForLaunchEvent.Length; i++)
        {
            TriggerForLaunchEvent[i].SetActive(false);
        }
    }

    public void OnCurrentEvent(int Current)
    {
        Debug.Log("События: " + names[Current] + " Триггеров: " + TriggerForLaunchEvent[Current]);

        Current = TriggerForLaunchEvent.Length;

        if(Current >= TriggerForLaunchEvent.Length - 1)
        {
            Current = 0;
        }
        // Проверка массивов для names
        if(Current >= 0 && Current < names.Length -1 )
        {
            names[Current] = names[Current];
        }
        else{
            Current = names.Length + 1;
        }
        //Создаем коллайдер чтобы проверить с каким именно он сталкунлся для запуска триггера
        Collider[] hitCollider = Physics.OverlapBox(TriggerForLaunchEvent[Current].transform.position, TriggerForLaunchEvent[Current].transform.position, Quaternion.identity);
        hitCollider[Current] =  TriggerForLaunchEvent[Current].GetComponent<Collider>();

        if(hitCollider[Current].CompareTag("Player"))
        {
            TriggerForLaunchEvent[Current].gameObject.SetActive(false);
            Debug.Log(hitCollider[Current].ToString() + ":Включен Триггер" );
        }
    }
}
