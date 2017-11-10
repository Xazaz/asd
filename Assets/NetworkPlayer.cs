using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkPlayer : NetworkBehaviour {

	[SyncVar]
	public int hp = 10;

	public CubeGestureListener gestureListener;
	public GameObject[] gameplayObj;

	public bool canWall = true;

	// Use this for initialization
	void Start () 
	{
		gestureListener = CubeGestureListener.Instance;

		if (!GetComponent<NetworkIdentity>().hasAuthority)
		{
			GetComponent<AvatarController>().enabled = false;
		}

		if (Network.isServer)
		{
			Debug.Log("I am server");
			transform.position = new Vector3(0, 0, 30);
			transform.eulerAngles = new Vector3(0, 180, 0);
		}

		Debug.Log("isServer " + Network.isServer);
		Debug.Log("isClient " + Network.isClient);
		Debug.Log("isClient " + Network.peerType);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (gestureListener.IsSwipeUp())
            if (canWall)
                StartCoroutine(wallUp(0));


		if (gestureListener.IsSwipeDown())
			if (canWall) 
				StartCoroutine(wallUp(1));

		if (gestureListener.IsSwipeLeft())
		{
			GameObject ball = (GameObject)Instantiate(NetworkManager.singleton.spawnPrefabs[0], new Vector3(transform.position.x, 2.6f, transform.position.z), transform.rotation);
			NetworkServer.Spawn(ball);
		}

		if (gestureListener.IsSwipeRight())
		{
			GameObject ball = (GameObject)Instantiate(NetworkManager.singleton.spawnPrefabs[1], new Vector3(transform.position.x, 2.6f, transform.position.z), transform.rotation);
			NetworkServer.Spawn(ball);

		}
	}

	IEnumerator wallUp(int wall)
	{
		canWall = false;

		do
		{
			gameplayObj[wall].transform.Translate(Vector3.up * Time.deltaTime * 8);
			yield return null;
		}while (gameplayObj[wall].transform.position.y <= 1.3f);

		yield return new WaitForSeconds(1f);

		do
		{
			gameplayObj[wall].transform.Translate(-Vector3.up * Time.deltaTime * 8);
			yield return null;
		}while (gameplayObj[wall].transform.position.y >= -1.6f);

		canWall = true;
	}



}
