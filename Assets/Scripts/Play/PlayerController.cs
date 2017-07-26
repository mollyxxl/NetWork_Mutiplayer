using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PaddleController {

	void Update () {
        base.Update();
        if (Input.GetKey(KeyCode.UpArrow))
        {
            MoveUp();
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            MoveDown();
        }
	}
}
