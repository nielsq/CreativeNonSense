using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{


    //var
    public float speed = 1.0f;
    public bool doubleJump = true;
    public float updates = 0.5f;
    public Vector3 JumpVector = new Vector3(0.0f, 7.0f, 0.0f);

    private bool pressJump = true;
    private bool JumpCoolDown = false;
    private bool IsGrounded;

    private Vector3 inputRotation;
    private Vector3 mousePlacement;
    private Vector3 screenCentre;

    
    float tempTime;

    // Use this for initialization
    void Start()
    {
        // Cursor.visible = false;
        this.name = "spieler";

    }
    
    // Update is called once per frame
    void Update()
    {

        //https://answers.unity.com/questions/10615/rotate-objectweapon-towards-mouse-cursor-2d.html
        var mouse = Input.mousePosition;
        var screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
        var offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
        var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, -angle +180, 0 );


        //bewegung mit WASD
        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            //this.transform.Translate(0.0f, 0.0f, 1.0f * speed);
            transform.Translate(0.0f, 0.0f, 1.0f * speed, Space.World);


        }

        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            transform.Translate(-1.0f * speed, 0.0f, 0.0f, Space.World);
        }

        if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            transform.Translate(0.0f, 0.0f, -1.0f * speed, Space.World);
        }

        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {

            transform.Translate(1.0f * speed, 0.0f, 0.0f, Space.World);

        }


        //damit wird die geschwindigkeit verringert falls zwei tasten ( WA/WD SA/SD)  gedrückt werden.
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            //this.transform.Translate(-0.5f * speed, 0.0f, 0.5f * speed);
            transform.Translate(-0.5f * speed, 0.0f, 0.5f * speed, Space.World);
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {

            transform.Translate(0.5f * speed, 0.0f, 0.5f * speed, Space.World);
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {

            transform.Translate(-0.5f * speed, 0.0f, -0.5f * speed, Space.World);
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {

            transform.Translate(0.5f * speed, 0.0f, -0.5f * speed, Space.World);
        }


        //Jump


        if (!Input.GetKey(KeyCode.Space))
        {
            pressJump = true;
        }

        if (Input.GetKey(KeyCode.Space) && pressJump)
        {
            pressJump = false;
            if (doubleJump)
            {

                if (IsGrounded)
                {
                    GetComponent<Rigidbody>().AddForce(JumpVector, ForceMode.Impulse);
                    Debug.Log("jump");
                } else if (!JumpCoolDown)
                {
                    JumpCoolDown = true;
                    GetComponent<Rigidbody>().AddForce(JumpVector, ForceMode.Impulse);
                    Debug.Log("double");
                }
            }
            else
            { 
                if (IsGrounded)
                {
                    GetComponent<Rigidbody>().AddForce(JumpVector, ForceMode.Impulse);
                }
                
            }

            
        }


        tempTime += Time.deltaTime;
        if (tempTime > updates)
        {
            tempTime = 0;
            UpdateEveryX();
        }


    }



    void UpdateEveryX()
    {

        

    }

    void OnCollisionStay(Collision collisionInfo)
    {
        IsGrounded = true;
        JumpCoolDown = false;


    }

    void OnCollisionExit(Collision collisionInfo)
    {
        IsGrounded = false;

    }





}


   


