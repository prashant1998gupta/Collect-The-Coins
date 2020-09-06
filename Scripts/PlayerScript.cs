using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    //Rigidbody2D body;

    public float moveSpeed = 5;

    string buttonPressed;

    public const string UP  = "up";
    public const string DOWN = "down";
    public const string LEFT = "left";
    public const string RIGHT = "right";

    int coins = 0;

    public Rigidbody2D body;
//    GameObject prefab = Resources.Load("Collect") as GameObject;

        // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D col) 
    {
        if (col.gameObject.tag == "Coin")
        {
            Destroy(col.gameObject);
            coins += 1;

            Debug.Log(coins);

        }

/* This one doesn't work, but the one after does.
        if (!col.gameObject.activeInHierarchy)
        {
            SceneManager.LoadScene(sceneBuildIndex: 1);
        }
*/
        if (coins == 4)
        {
            SceneManager.LoadScene(sceneBuildIndex: 1);
        }

    }
    

    void Start()
    {
        body = GetComponent<Rigidbody2D>(); 
    
    /*
        if ((gameObject.tag = "Coin") < 1)
        {
            SceneManager.LoadScene(sceneName: "fin");
        }       */
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            buttonPressed = UP;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            buttonPressed = DOWN;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            buttonPressed = LEFT;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            buttonPressed = RIGHT;
        }
        else if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        // This next section is for the other kind of movement
        /*
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            buttonPressed = RIGHT;
            transform.position += transform.right * (Time.deltaTime * moveSpeed);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            buttonPressed = UP;
            transform.position += transform.up * (Time.deltaTime * moveSpeed);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            buttonPressed = DOWN;
            transform.position -= transform.up * (Time.deltaTime * moveSpeed);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            buttonPressed = LEFT;
            transform.position -= transform.right * (Time.deltaTime * moveSpeed);
        }
        */

        else
        {
            buttonPressed = null;
        }
    }

    private void FixedUpdate() 
    {

        // Simple move. Does not allow diagonal movement.
        if(buttonPressed == UP)
        {
            body.velocity = new Vector2(0, moveSpeed);
        }
        else if(buttonPressed == DOWN)
        {
            body.velocity = new Vector2(0, -moveSpeed);
        }
        else if(buttonPressed == LEFT)
        {
            body.velocity = new Vector2(-moveSpeed, 0);
        }
        else if (buttonPressed == RIGHT)
        {
            body.velocity = new Vector2(moveSpeed, 0);
        }
        else
        {
            body.velocity = new Vector2(0, 0);
        }
    }
}
