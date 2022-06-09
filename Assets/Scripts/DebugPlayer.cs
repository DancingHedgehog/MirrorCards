using UnityEngine;
using Mirror;

public class DebugPlayer : NetworkBehaviour
{
	[SyncVar(hook = nameof(OnHelloCountChanged))]
	int helloCount = 0;

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

		if (isLocalPlayer) // important check!
		{
			if (Input.GetKeyDown(KeyCode.X))
			{
				Debug.Log("Send Hello 4 to the server");
				Hello(4);
			}
		}
	}

	public override void OnStartServer()
	{
		base.OnStartServer();
		Debug.Log("Player has been spawned on the server!");
	}

	[Command] // Called on client, run on server
	void Hello(int number)
	{
		Debug.Log("Recieved Hello from Client! " + number);
		helloCount++;
		ReplyHello();
	}

	[TargetRpc]
	void ReplyHello()
	{
		Debug.Log("Recieved Hello from Server!");
	}

	[ClientRpc] // called on server, but runs on all clients
	void TooHigh()
	{
		Debug.Log("Too high");
	}

	void OnHelloCountChanged(int oldValue, int newValue)
	{
		Debug.LogWarning($"Player with netId {netId} had {oldValue} hellos, but now has {newValue} hellos");
	}
}
