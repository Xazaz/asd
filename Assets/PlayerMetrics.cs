using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class PlayerMetrics : MonoBehaviour {

    public byte hp;
    public bool canWall = true;
	public GameObject[] gameplayObj;
	public bool isAI;

	Animator anim;
    public Text healthText;

    //Audio
    public AudioClip spell1;
    public AudioClip block1;
    private AudioSource Source;
    
    void Start () 
	{
		Reset();
		anim = GetComponent<Animator>();
        Source = GetComponent<AudioSource>();
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
            Source.PlayOneShot(block1, 0.7F);
            if (isAI)
			{
				anim.Play("Block");
                Source.PlayOneShot(block1, 0.7F);
            }
		}
	}

	public void SwipeDown()
	{
		if (canWall)
		{
			StartCoroutine(wallUp(1));
            Source.PlayOneShot(block1, 0.7F);
            if (isAI)
			{
				anim.Play("Block");
                Source.PlayOneShot(block1, 0.7F);
            }
		}
	}

	public void SwipeLeft()
	{
        Instantiate(gameplayObj[2], new Vector3(transform.position.x, 2.6f, transform.position.z) + transform.forward*2, transform.rotation);
        Source.PlayOneShot(spell1, 0.7F);
        if (isAI)
		{
			anim.Play("Attack1");
            Source.PlayOneShot(spell1, 0.7F);
        }
	}

	public void SwipeRight()
	{
		Instantiate(gameplayObj[3], new Vector3(transform.position.x, 2.6f, transform.position.z) + transform.forward*2, transform.rotation);
        anim.Play("Attack2");
        Source.PlayOneShot(spell1, 0.7F);
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
