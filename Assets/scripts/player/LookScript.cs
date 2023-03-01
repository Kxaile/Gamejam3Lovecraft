using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class LookScript : MonoBehaviour  
{

    public Transform PlayerCam;
    public Transform SeatPos;
    public Transform TableViewPos;
    public bool LookingDown;
    public bool canLook = false;
    public float lookPosition;
    public float viewLimit;

    public float yRotationLimit = 88f;
    public float xRotationLimit = 88f;

    public float sensitivity = 50f;

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            LookTable();
        }
    }



	private void Start()
	{
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        transform.eulerAngles = new Vector3(0, 0, 0);
        canLook = true;
    }
	private void FixedUpdate()
    {
        if (!LookingDown && canLook)
		{
            /*yRotation = Input.GetAxis("Mouse Y") * -sensitivity;
            xRotation = Input.GetAxis("Mouse X") * sensitivity;

            Quaternion unclampedCameraRotation = transform.localRotation;
            transform.localRotation *= Quaternion.Euler(yRotation, xRotation, 0);
            transform.localEulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);

            if (transform.eulerAngles.x < -90 && transform.eulerAngles.x > 90)
            {
                transform.localRotation = unclampedCameraRotation;
            }*/

            float yaw = sensitivity * Input.GetAxis("Mouse X") * Time.deltaTime;
            float pitch = -sensitivity * Input.GetAxis("Mouse Y") * Time.deltaTime;

            transform.localRotation *= Quaternion.Euler(0, yaw, 0);


            Quaternion unclampedCameraRotation = transform.localRotation;
            transform.localRotation *= Quaternion.Euler(pitch, 0, 0);

            if (Vector3.Angle(transform.forward, Vector3.forward) > 70f)
            {
                transform.localRotation = unclampedCameraRotation;
            }

            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 0);
        }
    }    
    
    public void LookDown()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
        LookingDown = true;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        LeanTween.move(PlayerCam.gameObject, TableViewPos.transform, 0.1f).setEaseOutCubic();
        LeanTween.rotate(PlayerCam.gameObject, TableViewPos.eulerAngles, 0.1f).setEaseOutCubic();
        //PlayerCam.position = TableViewPos.position;
        //PlayerCam.rotation = TableViewPos.rotation;
    }
    public void LookUp()
    {
        LeanTween.move(PlayerCam.gameObject, SeatPos.transform, 0.1f).setEaseOutCubic();
        LeanTween.rotate(PlayerCam.gameObject, SeatPos.eulerAngles, 0.1f).setEaseOutCubic();
        //PlayerCam.position = SeatPos.position;
        //PlayerCam.rotation = SeatPos.rotation;
        LookingDown = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void LookTable()
    {
        if(LookingDown == true)
        {
            LookUp();
        }
        else
        {
            LookDown();
        }
    }




}
