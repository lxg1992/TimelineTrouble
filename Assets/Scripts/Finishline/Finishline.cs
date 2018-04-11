using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finishline : MonoBehaviour {

    private Animator timeMachineAnimator;
    private bool isTouching = false;
    public GameObject smoke;

    //to delete once finishline is actually done
    private bool touched = false;

	// Use this for initialization
	void Start () {
        timeMachineAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        
        if (target.gameObject.tag == "Player" && touched == false)
        {
            isTouching = true;
            touched = true;
            Invoke("Smoke", 0.75f);

        }
    }

    public void PrepareSmoke()
    {
        Invoke("Smoke", 0.75f);
    }

    void Smoke()
    {
        Instantiate(smoke, this.transform.position, this.transform.rotation);
    }
	
	// Update is called once per frame
	void Update () {
        timeMachineAnimator.SetBool("PlayerTouch", isTouching);
	}
}
