using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class MyNetWorkManager:NetworkManager  {

    private bool isHost = false;

    void Update()
    { 
        //满足开始条件并且按下Space键 开始游戏
        if(CanStartGame()&&Input.GetKeyDown(KeyCode.Space))
        {
            GameObject ball = FindObjectsOfType<Ball>().Length > 0 ? FindObjectsOfType<Ball>()[0].gameObject as GameObject : null;
            if (ball == null)
                ball = Instantiate(spawnPrefabs[0], Vector3.zero, Quaternion.identity) as GameObject;
            NetworkServer.Spawn(ball);

            //添加速度
            ball.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(Random.Range(-1f, 1f)) * Random.Range(4f, 6f),
                Mathf.Sign(Random.Range(-1f, 1f)) * Random.Range(4f, 6f));

            Debug.Log("速度" + ball.GetComponent<Rigidbody2D>().velocity);
        }
    }

    private bool CanStartGame()
    {
        return NetworkServer.connections.Count == 2 && isHost;
    }
    public override void OnStartHost()
    {
        base.OnStartHost();
        isHost = true;
    }

    public void OnGUI()
    { 
    	GUILayout.Label ("Client connections " + NetworkServer.connections.Count + "/2");
    }
}
