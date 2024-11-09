using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] public GameObject _Active;

    // Start is called before the first frame update
    void Start()
    {
        if(_Active is null)
        {
            _Active = GetComponent<GameObject>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        OnNextScene();
    }

    public void OnNextScene()
    {
        bool ActiveScene = _Active.activeSelf;
        if(!ActiveScene)
        {
            SceneManager.LoadScene("Game");
        }
    }
}
