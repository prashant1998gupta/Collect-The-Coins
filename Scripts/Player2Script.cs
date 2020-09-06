using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player2Script : MonoBehaviour
{

    public float moveSpeed = 5;

    private const string RIGHT = "right";
    string buttonPressed;
    Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        
        body = GetComponent<Rigidbody2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        // to get movement here, i will need to multiply delta time by some move variable
        // I will use transform to make the character move with the arrow keys.

        if (Input.GetKey(KeyCode.RightArrow))
        {
            buttonPressed = RIGHT;
            transform.position += transform.right * (Time.deltaTime * moveSpeed);
        }
    }
}
