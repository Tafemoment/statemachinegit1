using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    int numValue = 37;
    float decLocation = 8.98f;
    string anyCharacters;
    bool falsch = true;


    public float zoom = -1;

    // Update is called once per frame
    public void Update()
    {
        Movement();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Please let go of me");
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Thank you");
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("Releasing Deadly Neurotoxin");
        }



    }

    void Movement()
    {
        //Input.GetAxis("Horizontal")
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        Vector2 move = new Vector2(xAxis, yAxis);

        move.Normalize();
        move *= zoom * Time.deltaTime;

        transform.position += (Vector3)move;
    }

    public void OldMovement()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector2 playerPosition = transform.position;
            playerPosition.y += zoom * Time.deltaTime;
            transform.position = playerPosition;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector2 playerPosition = transform.position;
            playerPosition.y -= zoom * Time.deltaTime;
            transform.position = playerPosition;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector2 playerPosition = transform.position;
            playerPosition.x += zoom * Time.deltaTime;
            transform.position = playerPosition;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector2 playerPosition = transform.position;
            playerPosition.x -= zoom * Time.deltaTime;
            transform.position = playerPosition;
        }
    }
}


