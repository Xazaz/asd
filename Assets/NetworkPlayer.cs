using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkPlayer : NetworkBehaviour {

	[SyncVar]
	public int hp = 10;

	public CubeGestureListener gestureListener;
	public GameObject[] gameplayObj;

	bool canWall = true;

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
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (gestureListener.IsSwipeUp())
		{
			if (canWall) StartCoroutine(wallUp(gameplayObj[0]));

			Debug.Log("testssadsadsa");
		}


		if (gestureListener.IsSwipeDown())
		if (canWall) StartCoroutine(wallUp(gameplayObj[1]));

		if (gestureListener.IsSwipeLeft())
		{
			NetworkServer.Spawn(gameplayObj[2]);
		}

		if (gestureListener.IsSwipeRight())
		{
			NetworkServer.Spawn(gameplayObj[3]);
		}
	}

	IEnumerator wallUp(GameObject wall)
	{
		canWall = false;
		do
		{
			wall.transform.Translate(Vector3.up * Time.deltaTime * 5);
			yield return null;
		}while (wall.transform.position.y >= 1.3);

		yield return new WaitForSeconds(0.6f);

		do
		{
			wall.transform.Translate(-Vector3.up * Time.deltaTime * 5);
			yield return null;
		}while (wall.transform.position.y <= 1.6);

		canWall = true;
	}



}
