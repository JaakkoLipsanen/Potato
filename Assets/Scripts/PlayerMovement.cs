using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    const float ROTATION_PER_SECOND = 150;
    const float FORCE_PER_SECOND = 500;

    Rigidbody2D rigidbody;


    public KeyCode Forward = KeyCode.W;
    public KeyCode Backwards = KeyCode.S;
    public KeyCode RotateLeft = KeyCode.A;
    public KeyCode RotateRight = KeyCode.D;
    public float Speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if(!GameManager.Instance.CanPlayerMove) 
        {
            rigidbody.AddForce(-rigidbody.velocity * Time.deltaTime);
            return; 
        }

        if(Input.GetKey(Forward))
        {
            rigidbody.AddForce(transform.up * FORCE_PER_SECOND * Time.deltaTime * Speed);
        }

        if (Input.GetKey(Backwards))
        {
            rigidbody.AddForce(transform.up * -FORCE_PER_SECOND * Time.deltaTime * Speed);
        }

        if (Input.GetKey(RotateLeft))
        {
            transform.Rotate(Vector3.forward * ROTATION_PER_SECOND * Time.deltaTime);
        }

        if (Input.GetKey(RotateRight))
        {
            transform.Rotate(Vector3.forward * -ROTATION_PER_SECOND * Time.deltaTime);
        }
    }
}
