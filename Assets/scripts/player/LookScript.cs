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
        /*
         * Qaternions dont project negative angles to euler, meaning we cant just rely on angle < limit to work 
         * so we need to check against both possible extremes 
         */

        //var mousePos = Input.mousePosition;
        //mousePos.x -= Screen.width / 2;
        //mousePos.y -= Screen.height / 2;

        //print(mousePos.x + ", " + mousePos.y); // mouse coords

        //var MouseDistance = new Vector2((mousePos.x / (Screen.width / 2)) * 5, (mousePos.y / (Screen.height / 2)) * 5); // get mouse distance from centre 
        //Vector3 TargetRot = new Vector3(-MouseDistance.y, MouseDistance.x, 0f); //making rot vector

        //print(TargetRot);  // rot vector

        //this.transform.localEulerAngles = TargetRot; // offsettign CAMERA NOT the holder

        if (!LookingDown && canLook)
		{
            /*if (mousePos.x > Screen.width / 5)
            {
                if (PlayerCam.localRotation.eulerAngles.y < viewLimit || PlayerCam.localRotation.eulerAngles.y >= 360 - viewLimit)
                {
                    lookPosition++;
                    PlayerCam.rotation = Quaternion.Euler(0, lookPosition, 0);
                }
            }
            if (mousePos.x < -Screen.width / 5)
            {
                if (PlayerCam.localRotation.eulerAngles.y > 360 -viewLimit || PlayerCam.localRotation.eulerAngles.y <= viewLimit+5)
                {
                    lookPosition--;
                    PlayerCam.rotation = Quaternion.Euler(0, lookPosition, 0);
                }
            }*/


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
