using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalManager : MonoBehaviour {
    public GameObject[] screens;
    public PlayerMetrics[] playerObjs;
    public CubeGestureListener gestureListener;

    // Use this for initialization
    void Start () {
        gestureListener = CubeGestureListener.Instance;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (gestureListener.IsSwipeUp())
        {

        }


        if (gestureListener.IsSwipeDown())
        {

        }

        if (gestureListener.IsSwipeLeft())
        {
        }

        if (gestureListener.IsSwipeRight())
        {

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
    }
}
