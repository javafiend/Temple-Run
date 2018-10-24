using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    public float myCoolTimer = 30;
    public bool start = false;
    private Text timerText;
    // Use this for initialization
    void Start () {
        timerText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {   
        // wait until character is ready to start timer
        if (Time.timeSinceLevelLoad >= 3f)
        {
            myCoolTimer -= Time.deltaTime;
            timerText.text = myCoolTimer.ToString("f0");
            
        }
        
    }
}
