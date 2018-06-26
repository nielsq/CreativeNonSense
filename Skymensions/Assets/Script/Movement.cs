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
    
    float tempTime;

    // Use this for initialization
    void Start()
    {

    }
    
    // Update is called once per frame
    void Update()
    {

        //bewegung mit WASD
        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(0.0f, 0.0f, 1.0f * speed);
        }

        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(-1.0f * speed, 0.0f, 0.0f);
        }

        if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(0.0f, 0.0f, -1.0f * speed);
        }

        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(1.0f * speed, 0.0f, 0.0f);
        }


        //damit wird die geschwindigkeit verringert falls zwei tasten ( WA/WD SA/SD)  gedrückt werden.
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(-0.5f * speed, 0.0f, 0.5f * speed);
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(0.5f * speed, 0.0f, 0.5f * speed);
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(-0.5f * speed, 0.0f, -0.5f * speed);
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(0.5f * speed, 0.0f, -0.5f * speed);
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
        Debug.Log("isGrounded");

    }

    void OnCollisionExit(Collision collisionInfo)
    {
        IsGrounded = false;
        Debug.Log("not");
    }





}


   


