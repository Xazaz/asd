using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Projectile : NetworkBehaviour {

	float timeDelta;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(Vector3.forward * Time.deltaTime * 5);
		timeDelta += Time.deltaTime;
		if (timeDelta > 8) Network.Destroy(gameObject);
	}

	void OnTriggerEnter3D(Collider other)
	{
		NetworkPlayer temp;
		if ((temp = other.GetComponent<NetworkPlayer>()) != null)
		{
			--temp.hp;
		}

		if (other.tag == "FireWall")
		{
			if (gameObject.tag == "Ice")
			{
				Network.Destroy(gameObject);
			}
		}

		if (other.tag == "IceWall")
		{
			if (gameObject.tag == "Fire")
			{
				Network.Destroy(gameObject);
			}
		}

	}
}
