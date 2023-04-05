using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 25.0f;

    private CharacterController controller;

    public Transform cameraLocation;
    private float mouseSensitivity = 2.0f;

    public AudioSource runFx;

    private Touch theTouch;
    private Vector2 touchStartPosition, touchEndPosition;
    private string direction;

    public FixedJoystick joystick;


    // Start is called before the first frame update
    private void Start()
    {
        controller = GetComponent<CharacterController>();
          
    }

    // Update is called once per frame
    private void Update()
    {


        //#if UNITY_ANDRIOD || UNITY_IOS
        if (Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);

            if(theTouch.phase == TouchPhase.Began)
            {
                touchStartPosition = theTouch.position;
            }
                else if(theTouch.phase == TouchPhase.Moved || theTouch.phase == TouchPhase.Ended)
                {
                    touchEndPosition = theTouch.position;

                    float x = touchEndPosition.x - touchStartPosition.x;
                    float y = touchEndPosition.y - touchStartPosition.y;

                if(Mathf.Abs(x) == 0 && Mathf.Abs(y) == 0)
                {
                    direction = "tapped";
                   
                }
                else if(Mathf.Abs(x) > Mathf.Abs(y))
                {
                    direction = x > 0 ? "right" : "left";
                    

                }
                else
                {
                    direction = y > 0 ? "up" : "down";

                }

            }
            Debug.Log("Mobile Input Test: " + direction);

    }
    
//#endif
        Move();
        Rotate();
    }


    private void Move()
    {
        float horz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        float horzJoy = joystick.Horizontal;
        float vertJoy = joystick.Vertical;

        Vector3 moveJoy = transform.forward * vertJoy + transform.right * horzJoy;
        Vector3 move = (horz * transform.right) + (vert * transform.forward);

        runFx.Play();


        controller.Move(moveJoy);
        controller.Move(move);

    }

    private void Rotate()
    {

        float horzJoy = joystick.Horizontal;
        float horz = Input.GetAxis("Horizontal");

        transform.Rotate(0, horzJoy * mouseSensitivity, 0);
        transform.Rotate(0, horz * mouseSensitivity, 0);
        cameraLocation.LookAt(transform);
    }

    private void OnCollisionEnter(Collision collision)
    {
       /* if (collision.gameObject.tag == "Ring")
        {
            Debug.Log("Collision Detected");
            GameSceneManager.gameWin = true;

        }
       */
       if (collision.gameObject.tag == "Seek")
        {
            Debug.Log("Collision Detected");
            GameSceneManager.gameOver = true;
        }
        if (collision.gameObject.tag == "Flee")
        {
            Debug.Log("Collision Detected");
            GameSceneManager.gameWin = true;
        }


    }
}
