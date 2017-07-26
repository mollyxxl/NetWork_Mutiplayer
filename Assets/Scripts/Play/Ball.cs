using UnityEngine;
using UnityEngine.Networking;
public class Ball : NetworkBehaviour  {

    private bool started = false;
    private Rigidbody2D rigidbody;
    private ScoreManager scoreManager;    
    private MyNetWorkManager networkManager;

	// Use this for initialization
	void Start () {
        scoreManager = FindObjectOfType<ScoreManager>();
        rigidbody = GetComponent<Rigidbody2D>();
        networkManager = FindObjectOfType<MyNetWorkManager>();
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerOneGoal")
        {
            ReSpawn();
            scoreManager.PlayerTwoScores();
        }
        else if (collision.gameObject.tag == "PlayerTwoGoal")
        {
            ReSpawn();
            scoreManager.PlayerOneScores();
        }
    }

    private void ReSpawn()
    {
        started = false;
        this.transform.position = Vector3.zero;
        rigidbody.velocity = Vector2.zero;
    }
}
