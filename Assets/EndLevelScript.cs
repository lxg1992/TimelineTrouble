using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndLevelScript : MonoBehaviour {



	// Use this for initialization
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			if (SceneManager.GetActiveScene().buildIndex == (SceneManager.sceneCountInBuildSettings - 1)) {
				SceneManager.LoadScene (0);
			} else {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
				Debug.Log ("End activated");
			}
		}
	}
}
