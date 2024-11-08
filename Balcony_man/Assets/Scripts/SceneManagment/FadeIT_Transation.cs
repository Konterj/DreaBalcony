using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class FadeIT_Transation : MonoBehaviour
{

    private Image Fade;
    private float Visibale;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("OnFade", 2f);

    }

    public void OnFade()
    {
        Invoke("OnFade", 2f);
        Fade.CrossFadeAlpha(Visibale, 3f, true);
    }

    public void OnFadeIt()
    {

    }

}
