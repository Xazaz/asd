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
	public GameObject canvas, slider;

    public bool SpeechPhraseRecognized(string phraseTag, float condidence)
    {
        print(phraseTag);
		if (!canvas.activeSelf) return true;
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
				canvas.SetActive(false);
                break;
            case "CREATEE":
                print("CCC");
				NetworkManager.singleton.StartMatchMaker();
				NetworkManager.singleton.matchMaker.CreateMatch("test", 2, true, "", "", "", 0, 0, OnMatchCreate);
				canvas.SetActive(false);
                break;
            case "AII":
                print("AAA");
				canvas.SetActive(false);
                break;
            case "OPTION":
                print("OOO");
			if (slider.activeSelf)
				slider.SetActive(false);
			else
				slider.SetActive(true);
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
}

