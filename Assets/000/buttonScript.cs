using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class buttonScript : MonoBehaviour {
    public NetworkManager nm;
    public GameObject canvas, slider, localManager;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void clickStart()
    {
        print("AAA");
        canvas.SetActive(false);
        localManager.SetActive(true);
    }
    public void clickQuit()
    {
        print("QQQ");
        Application.Quit();
    }

    public void OnMatchCreate(bool success, string extendedInfo, MatchInfo matchInfo)
    {
        NetworkManager.singleton.StartHost();
    }

    public void OnMatchList(bool success, string extendedInfo, List<MatchInfoSnapshot> matches)
    {
        NetworkManager.singleton.matchMaker.JoinMatch(matches[0].networkId, "", "", "", 0, 0, OnMatchJoined);
    }

    public void OnMatchJoined(bool success, string extendedInfo, MatchInfo matchInfo)
    {


    }
}

