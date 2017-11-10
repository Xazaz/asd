using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class InterfaceVoice : MonoBehaviour, SpeechRecognitionInterface
{
    private bool playNow;
    private bool aiNow;
	public NetworkManager nm;

    public bool SpeechPhraseRecognized(string phraseTag, float condidence)
    {
        print(phraseTag);
        switch (phraseTag)
        {
            case "NOW":
                print("GGG");
                playNow = true;
                break;
            case "JOINN":
                print("JJJ");
				NetworkManager.singleton.StartMatchMaker();
				NetworkManager.singleton.matchMaker.ListMatches(0, 10, "", true, 0, 0, OnMatchList);
                break;
            case "CREATEE":
                print("CCC");
				NetworkManager.singleton.StartMatchMaker();
				NetworkManager.singleton.matchMaker.CreateMatch("test", 2, true, "", "", "", 0, 0, OnMatchCreate);
                break;
            case "AII":
                print("AAA");
                aiNow = true;
                break;
            case "QUITT":
                print("QQQ");
				Application.Quit();
                break;

        }
        return true;
    }

	public void OnMatchCreate(bool success, string extendedInfo, MatchInfo matchInfo)
	{
		NetworkManager.singleton.StartHost();
	}

	public void OnMatchList(bool success, string extendedInfo, List<MatchInfoSnapshot> matches)
	{
		NetworkManager.singleton.matchMaker.JoinMatch(matches[0].networkId, "" , "", "", 0, 0, OnMatchJoined);
	}

	public void OnMatchJoined(bool success, string extendedInfo, MatchInfo matchInfo)
	{
		
	}

    // invoked when a speech phrase gets recognized
    //public bool SpeechPhraseRecognized(string phraseTag, float condidence)
    //{
    ////    print(phraseTag);
    ////    switch (phraseTag)
    ////    {
    ////        case "PLAY":
    ////            print("GGG");
    ////            playNow = true;
    ////            Application.LoadLevel(1);
    ////            break;
    ////    }

    ////    return true;
    //}

    void FixedUpdate()
    {
      
    }
}

