using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeHandler : MonoBehaviour {

    private Animator animator;
    private bool smokeEntrance = false;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
    public void SmokeAway()
    {
        smokeEntrance = true;
        animator.SetBool("SmokeEntrance", smokeEntrance);
    }
}
