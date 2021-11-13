using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class adsManager : MonoBehaviour
{
    public static adsManager I;
   


    string adType;
    string gameId;
    void Awake()
    {
        I = this;

        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            adType = "Rewarded_iOS";
            gameId = "4430066"; // 내 iOS 게임아이디
        }
        else
        {
            adType = "Rewarded_Android";
            gameId = "4430067"; // 내 안드로이드 게임아이디
        }

        Advertisement.Initialize(gameId, true);
    }

    public void ShowRewardAd()
    {
        if (Advertisement.IsReady())
        {
            ShowOptions options = new ShowOptions { resultCallback = ResultAds };
            Advertisement.Show(adType, options);
        }
    }

    void ResultAds(ShowResult result)
    {
        Debug.Log("in resultads");
        switch (ShowResult.Finished)
        
        //switch (result)
        {
            case ShowResult.Failed:
                Debug.LogError("광고 보기에 실패했습니다.");
                break;
            case ShowResult.Skipped:
                Debug.Log("광고를 스킵했습니다.");
                break;
            case ShowResult.Finished:
                // 광고 보기 보상 기능 
                //GameManager.I.reGame();
                Debug.Log("adsmanager");
                GameObject.Find("wall_top").GetComponent<GameOver>().reGame();
               
                break;
        }
    }
}