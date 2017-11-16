using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LocalManager : MonoBehaviour {
    public GameObject[] screens;
    public PlayerMetrics[] playerObjs;
    CubeGestureListener gestureListener;

	//AI
	float AIClock, AIClock_max;

    // Use this for initialization
    void Start () 
	{
		AIClock = 0f;
		AIClock_max = 0f;
		if (Random.Range(0,2) == 1)
		{
			playerObjs[1].SwipeLeft();
		}
		else
		{
			playerObjs[1].SwipeRight();
		}

        gestureListener = CubeGestureListener.Instance;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (gestureListener.IsSwipeUp())
        {
			playerObjs[0].SwipeUp();
        }

        if (gestureListener.IsSwipeDown())
        {
			playerObjs[0].SwipeDown();
        }

        if (gestureListener.IsSwipeLeft())
        {
			playerObjs[0].SwipeLeft();
        }

        if (gestureListener.IsSwipeRight())
        {
			playerObjs[0].SwipeRight();
        }

		//AI
		AIClock += Time.deltaTime;
		if (AIClock >= AIClock_max)
		{
			if (Random.Range(0,3) >= 1)
			{
				if (Random.Range(0,2) == 1)
				{
					playerObjs[1].SwipeLeft();
				}
				else
				{
					playerObjs[1].SwipeRight();
				}
			}
			else
			{
				if (Random.Range(0,2) == 1)
				{
					playerObjs[1].SwipeUp();
				}
				else
				{
					playerObjs[1].SwipeDown();
				}
			}

			AIClock_max = Random.value + 1.5f;
		}
    }

    public void EndGame(bool isplayer)
    {
        playerObjs[0].gameObject.SetActive(false);
        playerObjs[1].gameObject.SetActive(false);
        if (isplayer)
        {
            screens[0].SetActive(true);
        }
        else
        {
            screens[1].SetActive(true);
        }

		GameObject.FindObjectOfType<LocalManager>().gameObject.SetActive(false);
        StartCoroutine(LeaveGame());
    }

    IEnumerator LeaveGame()
    {
        float time = 0;

        do
        {
            time += Time.deltaTime;
            yield return null;
        }
        while (time < 5);

		SceneManager.LoadScene(0);
    }
}
