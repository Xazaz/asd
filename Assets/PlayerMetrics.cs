using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMetrics : MonoBehaviour {

    public byte hp;
    public bool canWall = true;
	public GameObject[] gameplayObj;
	public bool isAI;

	Animator anim;
    public Text healthText;

    void Start () 
	{
		Reset();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isAI)
            healthText.text = "Monster HP: " + hp;
        else
            healthText.text = "Player HP: " + hp;
	}

    public void Reset()
    {
        hp = 10;
    }

	public void SwipeUp()
	{
		if (canWall) 
		{
			StartCoroutine(wallUp(0));
			if (isAI)
			{
				anim.Play("Block");
			}
		}
	}

	public void SwipeDown()
	{
		if (canWall)
		{
			StartCoroutine(wallUp(1));
			if (isAI)
			{
				anim.Play("Block");
			}
		}
	}

	public void SwipeLeft()
	{
		Instantiate(gameplayObj[2], new Vector3(transform.position.x, 2.6f, transform.position.z) + transform.forward*2, transform.rotation);
		if (isAI)
		{
			anim.Play("Attack1");
		}
	}

	public void SwipeRight()
	{
		Instantiate(gameplayObj[3], new Vector3(transform.position.x, 2.6f, transform.position.z) + transform.forward*2, transform.rotation);
		anim.Play("Attack2");
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
