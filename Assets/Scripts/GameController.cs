using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool gameRunning;
    public GameObject inGameMenu;
    public GameObject mainMenuObj;

    private bool menuOpen;

    void Start()
    {
        //gameRunning = false;
    }

    void LateUpdate()
    {
        if (gameRunning)
        {
            if (Input.GetKeyDown(KeyCode.Escape)) OpenInGameMenu();
        }
        
    }

    void OpenInGameMenu()
    {
        menuOpen = !menuOpen;
        inGameMenu.SetActive(menuOpen);
    }

    public void SpawnNewPlane()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        Destroy(playerObj);
        Instantiate(mainMenuObj, transform.position, Quaternion.identity);
    }
}
