using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMetrics : MonoBehaviour {

    public byte hp;
    public bool canWall = true;
	public GameObject[] gameplayObj;

    void Start () 
	{
		Reset();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Reset()
    {
        hp = 10;
    }

	public void SwipeUp()
	{
		if (canWall) 
			StartCoroutine(wallUp(0));
	}

	public void SwipeDown()
	{
		if (canWall) 
			StartCoroutine(wallUp(1));
	}

	public void SwipeLeft()
	{
		Instantiate(gameplayObj[2], new Vector3(transform.position.x, 2.6f, transform.position.z) + transform.forward*2, transform.rotation);
	}

	public void SwipeRight()
	{
		Instantiate(gameplayObj[3], new Vector3(transform.position.x, 2.6f, transform.position.z) + transform.forward*2, transform.rotation);
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
