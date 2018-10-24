using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{

    public Image backgroundImage;

    private bool isShown = false;
    private float transition = 0.0f;

    // Use this for initialization
    void Start () {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update () {

        if (!isShown)
            return;
        transition += Time.deltaTime;
        
    }

    public void ToggleLevelMenu()
    {
        gameObject.SetActive(true);
        isShown = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");

    }
}
