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
            gameId = "4430066"; // �� iOS ���Ӿ��̵�
        }
        else
        {
            adType = "Rewarded_Android";
            gameId = "4430067"; // �� �ȵ���̵� ���Ӿ��̵�
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
                Debug.LogError("���� ���⿡ �����߽��ϴ�.");
                break;
            case ShowResult.Skipped:
                Debug.Log("���� ��ŵ�߽��ϴ�.");
                break;
            case ShowResult.Finished:
                // ���� ���� ���� ��� 
                //GameManager.I.reGame();
                Debug.Log("adsmanager");
                GameObject.Find("wall_top").GetComponent<GameOver>().reGame();
               
                break;
        }
    }
}