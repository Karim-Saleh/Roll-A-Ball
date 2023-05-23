using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX, movementY;
    public float speed = 10.0f;
    private int count;
    public static string playerName = "player";
    public TextMeshProUGUI countText;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCount();
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
        SetCount();
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

   

    private void SetCount() 
    {
        countText.text = playerName + " Score: " + count.ToString();
    }



    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("pickups")) 
        {
            count ++;
            other.gameObject.SetActive(false);
        }
    }
}
