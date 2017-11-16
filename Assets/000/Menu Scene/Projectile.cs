using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	float timeDelta;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(Vector3.forward * Time.deltaTime * 5);
		timeDelta += Time.deltaTime;
		if (timeDelta > 8) Destroy(gameObject);
	}

	void OnTriggerEnter(Collider other)
	{
		PlayerMetrics temp;
		if ((temp = other.GetComponent<PlayerMetrics>()) != null)
		{
			--temp.hp;
			if (temp.hp <=0)
			{
				GameObject.FindObjectOfType<LocalManager>().EndGame(other.gameObject.name != "Local Player");
			}
		}

		if (other.tag == "FireWall")
		{
			if (gameObject.tag == "Ice")
			{
				Destroy(gameObject);
			}
		}

		if (other.tag == "IceWall")
		{
			if (gameObject.tag == "Fire")
			{
				Destroy(gameObject);
			}
		}


	}
}
