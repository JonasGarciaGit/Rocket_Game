using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.UI;
using System;

public class AdmobController : MonoBehaviour
{
    //static alocar um espaço na memória para ser executado apenas uma vez.
    public static AdmobController instance;

    private string appId = "ca-app-pub-7731410972968504~5116558401";

    private RewardedAd rewardedAd;

    public bool publishingApp = false;


    void Awake() {
       if(instance == null)
       {
           instance = this;
           DontDestroyOnLoad(gameObject);
       }     
       else if(instance != this)
       {
           Destroy(gameObject);
       }
    }
    
    void Start()
    {
        MobileAds.Initialize(appId);

    }

    
    void Update()
    {
        
    }


     public void CreateAndLoadRewardedAd()
    {
        string adUnitId = "";
        
        if(publishingApp){
            //Chave de produção
            adUnitId = "ca-app-pub-7731410972968504/8288165588";
        }else{
            //Chave de homologação
            adUnitId = "ca-app-pub-3940256099942544/5224354917";
        }


        this.rewardedAd = new RewardedAd(adUnitId);

        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);
    }

    private void HandleRewardedAdClosed(object sender, EventArgs e)
    {
       //ad has been closed by the user
    }

    private void HandleUserEarnedReward(object sender, Reward e)
    {
        //Reward player
    }

    private void HandleRewardedAdLoaded(object sender, EventArgs e)
    {
        rewardedAd.Show();
    }
}
