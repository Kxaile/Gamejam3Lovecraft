using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class LookScript : MonoBehaviour  
{

    public Transform PlayerCam;
    public bool TurningLeft;
    public bool TurningRight;
    public float lookPosition;
    public float viewLimit;

    private void Update()
    {
        
       
    }
    private void FixedUpdate()
    {
        /*
         * Qaternions dont project negative angles to euler, meaning we cant just rely on angle < limit to work 
         * so we need to check against both possible extremes 
         */

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
    public void LookDown()
    {

    }
  
    
    
}
