using UnityEngine;
using Mirror;

public class TriadsNetworkManager : NetworkManager
{
	public override void OnStartServer()
	{
		base.OnStartServer();
		Debug.Log("Server start");
	}

	public override void OnStopServer()
	{
		base.OnStopServer();
		Debug.Log("Server stopped");
	}

	public override void OnClientConnect(NetworkConnection conn)
	{
		base.OnClientConnect();
		Debug.LogWarning("Connected to server!");
	}

	public override void OnClientDisconnect(NetworkConnection conn)
	{
		base.OnClientDisconnect();
		Debug.LogWarning("Client disconnected");
	}
}
