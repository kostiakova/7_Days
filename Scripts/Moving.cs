using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float runspeed = 10f;
    [SerializeField] float jumpPower = 10f;
    const float Gravity = 10f;
    [SerializeField] float movX, movZ;
    [SerializeField] public CharacterController CharContrl;
    public new Camera camera;
    public float lookspeed = 2f;
    public float lookXLimt = 45f;

    public GameObject Capsule;

    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0f;
    public bool canMove = true;

    [SerializeField] GameObject Panel;
    public bool isPaused;

    public GameObject Flashlight;
    string nameOfLight;

    public bool hasLIght, touchsLIght;


    void Start()
    {
        CharContrl = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        nameOfLight = Flashlight.name;
    }

    void Update()
    {
        Capsule.transform.position = transform.position;
        #region Handles Movement
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        float curSpeedX = canMove ? ((Input.GetKey(KeyCode.LeftShift)) ? runspeed : speed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? ((Input.GetKey(KeyCode.LeftShift)) ? runspeed : speed) * Input.GetAxis("Horizontal") : 0;
        float moveDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        #endregion

        #region Handles Jumping 
        if(Input.GetButton("Jump") && canMove && CharContrl.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = moveDirectionY;
        }
        if (!CharContrl.isGrounded)
        {
            moveDirection.y -= Gravity * Time.deltaTime;
        }
        #endregion

        #region Handles Rotation
        CharContrl.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += Input.GetAxis("Mouse Y") * lookspeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimt, lookXLimt);
            camera.transform.localRotation = Quaternion.Euler(-rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookspeed, 0);
        }
        #endregion

        #region Handles E-Button
        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3 cameraPosition = new Vector3(camera.transform.position.x, camera.transform.position.y, camera.transform.position.z);// + 0.25f
            Ray ray = new Ray(cameraPosition, camera.transform.forward);
            Debug.DrawRay(ray.origin, ray.direction * 4f);
            RaycastHit hitData;
            if (Physics.Raycast(ray, out hitData, 4f))
            {if (!(hitData.collider.name == "Player")) { Debug.Log(hitData.collider.name); }}
            if (touchsLIght)
            {
                hasLIght = true;
                PlayerPrefs.SetInt("HasLight", 1);
                //Debug.Log("ChangedPrefs");
            }

        }
        #endregion

        #region Handles Pause

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) {
                Time.timeScale = 1f;
                Panel.SetActive(false);
            }
            else
            {
                Time.timeScale = 0f;
                Panel.SetActive(true);
            }
            isPaused = !isPaused;
        }
        #endregion
    }

    #region Handles FlashLight detection
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.name == nameOfLight)
        {
            //Debug.Log("Collision!!!");
            touchsLIght = true;
        }
    }
    #endregion
}
