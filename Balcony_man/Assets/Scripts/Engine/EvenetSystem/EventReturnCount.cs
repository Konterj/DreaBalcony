using UnityEngine;

public class EventReturnCount : MonoBehaviour
{

    public int CountEvent;

    public EventManager GetEvent;

    public void Start()
    {
        if(GetEvent is null)
        {
            GetEvent = GetComponent<EventManager>();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Collision");
            Debug.Log(GetEvent.EventCurrent);
            SetCountEvent();
        }
    }

    public void SetCountEvent()
    {
        GetEvent.EventCurrent = CountEvent;
    }
}
