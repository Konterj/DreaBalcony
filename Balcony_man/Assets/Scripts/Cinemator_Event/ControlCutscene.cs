using Cinemachine;
using UnityEngine;

public class ControlCutscene : MonoBehaviour
{
    public GameObject Cutscene;
    public GameObject ActiveIs_Off;

    public CinemachineVirtualCamera CamCutscene;
    public Camera CamHead_Person;
 
    private void Update()
    {
        OnActived();
    }

    //Cheked Active
    public void OnActived()
    {
        bool Actived = ActiveIs_Off.activeSelf;
        Cutscene.SetActive(Actived);

        if(!Actived)
        {
            CamHead_Person = Camera.main;
        }
    }
}
