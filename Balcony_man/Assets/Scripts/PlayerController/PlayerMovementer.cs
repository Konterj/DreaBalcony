using UnityEngine;

public class PlayerMovementer : MonoBehaviour
{
    [Header("Player")]
    public Camera cam;
    // private AudioSource _source;
    //private AudioClip[] clips;

    [Header("Setting Player")]
    [SerializeField] public float moveSpeed = 2f;
    [SerializeField] public float Gravitytation = -9.8f;
    [SerializeField] public float Sensentivity = 100f;
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
    }

    public void OnIntilization()
    {
        _player = GetComponent<CharacterController>();
        // _source = GetComponent<AudioSource>();
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
        _player.Move(direction * Time.deltaTime);
        Gravity.y += Gravitytation * Time.deltaTime;
        _player.Move(Gravity * Time.deltaTime);
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
}
