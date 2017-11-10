using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class InterfaceScript : MonoBehaviour {
    public InteractionManager imManager;
    CubeGestureListener gestureListener;
    public NetworkManager nm;

    // Use this for initialization
    void Start () {
        gestureListener = CubeGestureListener.Instance;
        NetworkManager.singleton.StartMatchMaker();
        NetworkManager.singleton.matchMaker.CreateMatch("test", 2, true, "", "", "", 0, 0, OnMatchCreate);
    }

    public void OnMatchCreate(bool success, string extendedInfo, MatchInfo matchInfo)
    {
        NetworkManager.singleton.StartHost();
    }

    // Update is called once per frame
    void Update () {
        Debug.Log(imManager.leftHandState);
        Debug.Log(gestureListener.IsSwipeDown());
        Debug.Log(gestureListener.IsSwipeUp());
    }
    
}
