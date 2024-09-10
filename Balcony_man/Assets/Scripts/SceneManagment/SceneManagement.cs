using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagement : MonoBehaviour
{
    public void OnLoadScene(string nameScene){
        SceneManager.LoadScene(nameScene);
    }

    public void OnApplicationQuit()
    {
        OnApplicationQuit();
    }
}
