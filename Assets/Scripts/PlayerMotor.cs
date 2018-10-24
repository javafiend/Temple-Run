using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMotor : MonoBehaviour {
    public Timer t;
    private CharacterController controller;
    private Vector3 moveVector;
    private float speed = 5.0f;
    //private float jumpSpeed = 5.0f;
    private float verticalVelocity = 5.0f;
    private float gravity = 15.0f;
    public bool onGround;
    private Rigidbody rb;
    private float animationDuration = 3.0f;
    private bool isDead = false;
    private float startTime;

    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
        startTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {

        if (isDead)
            return;
        // level complete at 30 secs
        if (Time.timeSinceLevelLoad >= 33f)
        {
            Level();
        }
        // pause 3 secs
        if (Time.time - startTime < animationDuration)
        {
            t.start = true;
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }
        moveVector = Vector3.zero;

        if(controller.isGrounded)
        {
            verticalVelocity -= 7.5f;
            if (Input.GetButtonDown("Jump"))
                verticalVelocity = 9f;

        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        // X - Left and Right
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        // Y - Up and Down
        moveVector.y = verticalVelocity;
        // Z - Forward and Backward
        moveVector.z = speed;
        controller.Move (moveVector *Time.deltaTime);

	}

    public void SetSpeed(float modifier)
    {

    }
    // called when player collides into something
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Obstacle")
            Death();
    }
    // called when player dies
    private void Death()
    {
        isDead = true;
        GetComponent<Level>().OnDeath();
    }
    // called when player finishes level
    public void Level()
    {
        GetComponent<Level>().LevelUp();
    }
}
