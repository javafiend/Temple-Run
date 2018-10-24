using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    private float time = 0.0f;

    private int difficultyLevel = 1;
    //private int maxDifficultyLevel = 5;
    //private int timeToNextLevel = 0;

    private bool isDead = false;

    //public Text timeText;
    public DeathMenu deathMenu;
    public LevelMenu levelMenu;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isDead)
            return;
        
        
	}

    public void LevelUp()
    {
        levelMenu.ToggleLevelMenu();
    }

    public void OnDeath()
    {
        isDead = true;
        deathMenu.ToggleEndMenu();
    }
}
