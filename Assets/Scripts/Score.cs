using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

    GameObject[] gameMusic;

    private int startingMachines;
    private int machinesLeft;
    private float countdown;

	// Use this for initialization
	void Start () {
        
        startingMachines = GameObject.FindGameObjectsWithTag("Finish").Length;
        machinesLeft = GameObject.FindGameObjectsWithTag("Finish").Length;
        countdown = 10;
        Debug.Log("Starting Machines: " + startingMachines);

        //Game Music
        gameMusic = GameObject.FindGameObjectsWithTag("Music");
    }

    public void machineLeave()
    {
        machinesLeft -= 1;
        Debug.Log("Machines Left: " + machinesLeft);
    }
	
	// Update is called once per frame
	void Update () {

        /* Countdown, for score purposes to see how long for all 3 characters to reach after
        the first.
        */
        if (machinesLeft < startingMachines)
        {
            countdown -= Time.deltaTime;
        }

        if (machinesLeft == 0)
        {
            if (SceneManager.GetActiveScene().buildIndex == (SceneManager.sceneCountInBuildSettings - 1))
            {
                Destroy(gameMusic[0]);
                SceneManager.LoadScene(0);
            }
            else
            {
                Destroy(gameMusic[0]);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                Debug.Log("End activated");
            }
        }
    }
}
