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

    public Collider[]  hitCollider;
    public int Current;
    public void Start()
    {
        for(int i = 0; i < hitCollider.Length; i++)
        {
            if(hitCollider[i] is null)
            {
                hitCollider[i].GetComponent<Collider>();
            }
        }
    }

    public void OnCurrentEvent()
    {
        foreach(Collider other in hitCollider)
        {
            //fix there Code, write this code 06.09.2024/ 22:04:50 times
        }
    }
}
