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

    public float sensitivity = 2f;

    Vector2 rotation = Vector2.zero;

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

            rotation.x = Input.GetAxis("Mouse X");
            rotation.y = Input.GetAxis("Mouse Y");
            transform.localEulerAngles += new Vector3(-rotation.y * sensitivity, rotation.x * sensitivity);

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
