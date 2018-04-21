using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Explode : MonoBehaviour {

    public GameObject globals;
    private ScoreSheet scoreSheet;

    public Text displayText;

    public PlayerDebris playerDebris;
    public int totalDebris = 10;
    // Use this for initialization
    void Start() {
        scoreSheet = globals.GetComponent<ScoreSheet>();
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Deadly")
        {
            OnExplode();
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);

        }
    }

    void OnExplode()
    {
        var t = transform;

        for ( int i = 0; i < totalDebris; i ++ )
        {
            t.TransformPoint(0, -100, 0);
            var clone = Instantiate(playerDebris, t.position, Quaternion.identity) as PlayerDebris;
            var body2D = clone.GetComponent<Rigidbody2D>();
            body2D.AddForce(Vector3.right * Random.Range(-10000, 10000));
            body2D.AddForce(Vector3.up * Random.Range(5000, 20000));
        }
        ResetCountText();
        Destroy(gameObject);
    }

    private void ResetCountText()
    {
        scoreSheet.ResetScore();
        displayText.text = scoreSheet.ScoreText();
    }

}
 