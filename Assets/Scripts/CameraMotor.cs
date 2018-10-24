using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour {

    private Transform cameralook;
    private Vector3 startOffset;
    private Vector3 moveVector;

    private float transition = 0.0f;
    private float animationDuration = 3.0f;
    private Vector3 animationOffset = new Vector3 (0, 5, 5);

	// Use this for initialization
	void Start () {
        cameralook = GameObject.FindGameObjectWithTag ("Player").transform;
        startOffset = transform.position - cameralook.position;
	}
	
	// Update is called once per frame
	void Update () {
        moveVector = cameralook.position + startOffset;
        // X
        moveVector.x = 0;
        // Y
        moveVector.y = Mathf.Clamp(moveVector.y,3,5);
        
        if (transition > 1.0f)
        {
            transform.position = moveVector;
        }
        else
        {
            // Animation at the start of the game
            transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);
            transition += Time.deltaTime / animationDuration;
            transform.LookAt (cameralook.position + Vector3.up);
        }
        
	}
}
