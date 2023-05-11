using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCamScript : MonoBehaviour
{
    public int CurrentX;
    public int CurrentY;
    public bool LookingDown;
    public Transform LeftTransform;
    public Transform RightTransform;
    public Transform UpTransform;
    public Transform Table;
    public Transform Seat;
    public GameObject LeftCreature =null;
    public GameObject RightCreature =null;
    public GameObject UpCreature =null;
    public Canvas Tutorial;

    public QTE_Call Caller;
    public BookInteract book;
    public ritual rits;

    public Light Spotlight;

    // Start is called before the first frame update
    void Start()
    {
        Caller = GameObject.FindWithTag("RuntimeScripts").GetComponent<QTE_Call>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && !book.BookOpen && !rits.ritualsOpen)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (CurrentX == 0)
                {
                    LookLeft();
                }
                else if(CurrentX == 1)
                {
                    LookCenter();
                }
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (CurrentX == 0)
                {
                    LookRight();
                }
                else if (CurrentX == -1)
                {
                    LookCenter();
                }
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (CurrentY == 0) //&& CurrentX ==0)
                {
                    LookUp();
                }
                else if (CurrentY == -1 || CurrentX!=0)
                {
                    LookCenter();
                }
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (CurrentY == 0)
                {
                    looktable();
                }
                else if(CurrentY == 1)
                {
                    LookCenter();
                }
            }
        }
        if (CurrentY == -1)
        {
            LookingDown = true;
        }
        else
        {
            LookingDown = false;
        }
        if(CurrentX!= 0 || CurrentY==1)
        {
            Spotlight.gameObject.SetActive(true);
        }
        else
        {
            Spotlight.gameObject.SetActive(false);
        }
        //print(LookingDown);

        if (LeftCreature && CurrentX ==-1)
        {
            LeftCreature.GetComponent<CreatureScript>().currentStare += Time.deltaTime;
            print("leftLookCreature");
            if (!Caller.HasDefeatedCreature)
            {
                Tutorial.gameObject.SetActive(true);
            }
        }
        if(RightCreature && CurrentX == 1)
        {
            RightCreature.GetComponent<CreatureScript>().currentStare += Time.deltaTime;
            print("RightLookCreature");
            if (!Caller.HasDefeatedCreature)
            {
                Tutorial.gameObject.SetActive(true);
            }
        }
        if(UpCreature && CurrentY == 1)
        {
            UpCreature.GetComponent<CreatureScript>().currentStare += Time.deltaTime; 
            print("UpLookCreature");
            if (!Caller.HasDefeatedCreature)
            {
                Tutorial.gameObject.SetActive(true);
            }
        }
        

        
        
    }
    public void LookLeft()
    {
        LeanTween.move(this.gameObject, LeftTransform.transform, 0.4f).setEaseOutCubic();
        LeanTween.rotate(this.gameObject, LeftTransform.eulerAngles, 0.4f).setEaseOutCubic();
        CurrentX = -1;
        CurrentY = 0;
    }
    public void LookRight()
    {
        LeanTween.move(this.gameObject, RightTransform.transform, 0.4f).setEaseOutCubic();
        LeanTween.rotate(this.gameObject, RightTransform.eulerAngles, 0.4f).setEaseOutCubic();
        CurrentX = 1;
        CurrentY = 0;
    }
    public void LookUp()
    {
        LeanTween.move(this.gameObject, UpTransform.transform, 0.4f).setEaseOutCubic();
        LeanTween.rotate(this.gameObject, UpTransform.eulerAngles, 0.4f).setEaseOutCubic();
        CurrentX = 0;
        CurrentY = 1;
    }
    public void LookCenter()
    {
        LeanTween.move(this.gameObject, Seat.transform, 0.4f).setEaseOutCubic();
        LeanTween.rotate(this.gameObject, Seat.eulerAngles, 0.4f).setEaseOutCubic();
        CurrentX = 0;
        CurrentY = 0;
    }
    public void looktable()
    {
        LeanTween.move(this.gameObject, Table.transform, 0.4f).setEaseOutCubic();
        LeanTween.rotate(this.gameObject, Table.eulerAngles, 0.4f).setEaseOutCubic();
        CurrentX = 0;
        CurrentY = -1;
    }
}
