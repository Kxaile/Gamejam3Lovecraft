using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class LookScript : MonoBehaviour  
{

    public Transform PlayerCam;
    public Transform SeatPos;
    public Transform TableViewPos;
    public GameObject LeftAndRight;
    public bool TurningLeft;
    public bool TurningRight;
    public bool LookingDown;
    public float lookPosition;
    public float viewLimit;


    void Update()
    {

    }
    private void FixedUpdate()
    {
        /*
         * Qaternions dont project negative angles to euler, meaning we cant just rely on angle < limit to work 
         * so we need to check against both possible extremes 
         */

        var mousePos = Input.mousePosition;
        mousePos.x -= Screen.width / 2;
        mousePos.y -= Screen.height / 2;

        //print(mousePos.x + ", " + mousePos.y); // mouse coords

        var MouseDistance = new Vector2((mousePos.x / (Screen.width / 2)) * 5, (mousePos.y / (Screen.height / 2)) * 5); // get mouse distance from centre 
        Vector3 TargetRot = new Vector3(-MouseDistance.y, MouseDistance.x, 0f); //making rot vector

        //print(TargetRot);  // rot vector

        this.transform.localEulerAngles = TargetRot; // offsettign CAMERA NOT the holder


        if (TurningRight)
        {
            if (PlayerCam.localRotation.eulerAngles.y < viewLimit || PlayerCam.localRotation.eulerAngles.y >= 360 - viewLimit)
            {
                lookPosition++;
                PlayerCam.rotation = Quaternion.Euler(0, lookPosition, 0);
            }
        }
        if (TurningLeft)
        {
            if (PlayerCam.localRotation.eulerAngles.y > 360 -viewLimit || PlayerCam.localRotation.eulerAngles.y <= viewLimit+5)
            {
                lookPosition--;
                PlayerCam.rotation = Quaternion.Euler(0, lookPosition, 0);
            }
        }
    }
    public void LookLeft()
    {
        TurningLeft = true;
    }
    public void StopLeft()
    {
        TurningLeft = false;
    }
    public void LookRight()
    {
        TurningRight = true;
    }
    public void StopRight()
    {
        TurningRight = false;
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
    public void LookDown()
    {
        PlayerCam.position = TableViewPos.position;
        PlayerCam.rotation = TableViewPos.rotation;
        LookingDown = true;
        LeftAndRight.SetActive(false);
    }
    public void LookUp()
    {
        PlayerCam.position = SeatPos.position;
        PlayerCam.rotation = SeatPos.rotation;
        LookingDown = false;
        LeftAndRight.SetActive(true);
        lookPosition = 0f;

    }



}
