using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] Event _evenet;

    [SerializeField] public int EventCurrent{get;set;}
    private void Update()
    {
        GetEvent();
    }
    public void GetEvent(){

        _evenet.OnGetEvent();
        OnSetEvent();
    }

    public void OnSetEvent()
    {
        _evenet.Current = EventCurrent;
    }

}

[System.Serializable]
public class Event
{
    public string[] names;

    public int Current = 0;

    public void OnGetEvent()
    {
        if(Current > names.Length - 1)
        {
            Current = 0;
        }
    }

}
