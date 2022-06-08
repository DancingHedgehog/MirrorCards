using UnityEngine;
using Mirror;

public class DebugMovement : NetworkBehaviour
{
    void HandleMovement()
	{
		if (isLocalPlayer)
		{
			float moveHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime;
			float moveVertical = Input.GetAxis("Vertical") * Time.deltaTime;
			Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);
			transform.position += movement;
		}
	}

	void Update()
	{
		HandleMovement();
	}
}
