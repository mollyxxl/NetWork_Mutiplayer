using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PaddleController : NetworkBehaviour
{
    public float speed = 5f;
    public int maxField = 4;

	// Update is called once per frame
	public void Update () {
        if (!isLocalPlayer)
            return;

        this.transform.position = new Vector3(transform.position.x, Mathf.Clamp(this.transform.position.y, -maxField, maxField));
	}
    protected void MoveUp()
    {
        if (!isLocalPlayer)
            return;

        this.transform.Translate(new Vector3(0, speed * Time.deltaTime));
    }
    protected void MoveDown()
    {
        if (!isLocalPlayer)
            return;
        this.transform.Translate(new Vector3(0, -speed * Time.deltaTime));
    }
}
