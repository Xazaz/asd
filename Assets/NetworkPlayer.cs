﻿using System.Collections;
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
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (gestureListener.IsSwipeUp())
		{
            if (canWall)
            {
                StartCoroutine(wallUp(0));
            }
		}


		if (gestureListener.IsSwipeDown())
		if (canWall) StartCoroutine(wallUp(1));

		if (gestureListener.IsSwipeLeft())
		{
			GameObject tree = (GameObject)Instantiate(NetworkManager.singleton.spawnPrefabs[0], new Vector3(transform.position.x, 2.6f, transform.position.z), transform.rotation);
			NetworkServer.Spawn(tree);
			//NetworkServer.SpawnWithClientAuthority(gameplayObj[2], connectionToClient);
			//Network.Instantiate(gameplayObj[2], transform.position, transform.rotation, 0);
		}

		if (gestureListener.IsSwipeRight())
		{
			GameObject tree = (GameObject)Instantiate(NetworkManager.singleton.spawnPrefabs[1], new Vector3(transform.position.x, 2.6f, transform.position.z), transform.rotation);
			NetworkServer.Spawn(tree);
			//NetworkServer.SpawnWithClientAuthority(gameplayObj[3], connectionToClient);
			//Network.Instantiate(gameplayObj[3], transform.position, transform.rotation, 0);
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
