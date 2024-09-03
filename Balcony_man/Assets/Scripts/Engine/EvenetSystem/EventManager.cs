using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] Event _evenet;
    public void Start()
    {

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
        Debug.Log("События: " + names[Current] + "Триггеров: " + TriggerForLaunchEvent[Current]);

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
        Current = hitCollider.Length - 1;
        names[Current] = names.ToString();
        if(hitCollider[Current].CompareTag("Player"))
        {
            hitCollider[Current].gameObject.SetActive(false);
            Debug.Log(hitCollider[Current].ToString() + ":Включен" );
        }
    }
}
