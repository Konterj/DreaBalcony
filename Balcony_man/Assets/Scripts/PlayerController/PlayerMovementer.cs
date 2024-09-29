using System;
using UnityEngine;

public class PlayerMovementer : MonoBehaviour
{
    [Header("Player")]
    public Camera cam;

    [Header("Setting Player")]
    [SerializeField] public float moveSpeed = 2f;
    [SerializeField] public float Gravitytation = -9.8f;
    [SerializeField] public float Sensentivity = 100f;

    private AudioSource _source;
    public AudioClip[] clips;
    public float RadiusTrigger = 1f;

    private CharacterController _player;
    private float XRoted;
    private Vector3 Gravity;

    // Start is called before the first frame update
    void Start()
    {
        OnIntilization();
    }

    // Update is called once per frame
    void Update()
    {
        OnMovementer();
        OnRotatedCam();
        OnCheckGroundForAudio();
    }

    public void OnIntilization()
    {
        _player = GetComponent<CharacterController>();
        _source = GetComponent<AudioSource>(); //Get Source
        
        //CLips Get
        for(int i = 0; i < clips.Length; i++)
        {
            if(clips[i] is null)
            {
                clips[i] = GetComponent<AudioClip>();
            }
        }

        if(cam is null)
        {
            cam = GetComponent<Camera>();
        }
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    public void OnMovementer()
    {
        bool Ground = _player.isGrounded;
        if(Ground &&Gravity.y < 0)
        {
            Gravity.y = 0;
        }
        float forward = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float RightOrLeft = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        Vector3 direction = transform.forward * forward + transform.right * RightOrLeft;
        direction = Vector3.ClampMagnitude(direction, moveSpeed);
        _player.Move(direction);
        Gravity.y += Gravitytation * Time.deltaTime;
        _player.Move(Gravity);


        //LaunchBool Cheked Audio
        Vector3 Audio_Dir = direction;
        Mathf.Round(Audio_Dir.magnitude);
        //I doesn't thinkg it's work normally, but it's work
        if (Audio_Dir.magnitude != 0f)
        {
            Debug.Log("direction:  " + Audio_Dir.magnitude);
            if(!_source.isPlaying)
            {
                _source.Play();
            }
        }
        else if(Audio_Dir.magnitude == 0)
        {
            if(_source.isPlaying)
            {
                _source.Stop();
            }
        } 
    }

    private void OnRotatedCam()
    {
        float Y_rot = Input.GetAxis("Mouse Y") * Sensentivity * Time.deltaTime;
        float X_rot = Input.GetAxis("Mouse X") * Sensentivity * Time.deltaTime;
        XRoted -= Y_rot;
        XRoted = Mathf.Clamp(XRoted, -90, 90);
        cam.transform.localRotation = Quaternion.Euler(XRoted, 0f, 0f);
        _player.transform.Rotate(Vector3.up * X_rot);
    }

        private void OnCheckGroundForAudio()
    {
        Collider[] hitColliders;
        LayerMask grassLayer = LayerMask.GetMask("Grass");
        LayerMask floorLayer = LayerMask.GetMask("Floor");
        LayerMask concreteLayer = LayerMask.GetMask("Concrete");

        // Replace Vector3.down with the player's position
        hitColliders = Physics.OverlapSphere(transform.position, RadiusTrigger);

        // Loop through the colliders found by the overlap
        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.layer == LayerMask.NameToLayer("Grass"))
            {
                _source.clip = clips[0]; //set grass audio
            }
            else if (hitCollider.gameObject.layer == LayerMask.NameToLayer("Floor"))
            {
                _source.clip = clips[1];   // set wood audio
            }
            else if (hitCollider.gameObject.layer == LayerMask.NameToLayer("Concrete"))
            {
                _source.clip = clips[2]; // set concrete audio
            }
        }
    }
}
