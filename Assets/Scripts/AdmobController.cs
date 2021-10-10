using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class AdmobController : MonoBehaviour
{
    //static alocar um espaço na memória para ser executado apenas uma vez.
    public static AdmobController instance;

    private string appId = "ca-app-pub-7731410972968504~5116558401";

    private RewardBasedVideoAd rewardedAd;

    private BannerView adBanner;

    private InterstitialAd interstitialAd;

    public bool publishingApp = false;

    private string adUnitId, adBannerId, adInterstitialId;

    [SerializeField]
    private Collectable collectable;

    [SerializeField]
    private Text starsEanred;

    [SerializeField]
    Button BtnReward;

    [SerializeField]
    Button shopButton;

    [SerializeField]
    Button btnReturnMenu;
    [SerializeField]
    Button btnPlayAgain;

    [SerializeField] SaveStarsAmount saveStars;

    private bool alreadyWatchAds = false;
    
    void Start()
    {

        if (publishingApp)
        {
            //Chave de produção
            adUnitId = "ca-app-pub-7731410972968504/8288165588";
            adBannerId = "ca-app-pub-7731410972968504/2349728600";
            adInterstitialId = "ca-app-pub-7731410972968504/6782199140";
        }
        else
        {
            //Chave de homologação
            adBannerId = "ca-app-pub-3940256099942544/6300978111";
            adUnitId = "ca-app-pub-3940256099942544/5224354917";
            adInterstitialId = "ca-app-pub-3940256099942544/1033173712";
        }

        rewardedAd = RewardBasedVideoAd.Instance;

        if ("Menu_Rocket".Equals(SceneManager.GetActiveScene().name))
        {
            RequestBannerAd();
            RequestInterstitialAd();
        }


        MobileAds.Initialize(appId);

    }


    public void RequestInterstitialAd()
    {
        interstitialAd = new InterstitialAd(adInterstitialId);
        AdRequest request = new AdRequest.Builder().Build();
        interstitialAd.LoadAd(request);

        //attach events
        interstitialAd.OnAdLoaded += this.HandleOnAdLoaded;
        interstitialAd.OnAdOpening += this.HandleOnAdOpening;
        interstitialAd.OnAdClosed += this.HandleOnAdClosed;
    }

    public void ShowInterstitialAd()
    {
        if (interstitialAd.IsLoaded())
            interstitialAd.Show();
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
  
    }


    public void HandleOnAdOpening(object sender, EventArgs args)
    {
 
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        //this method executes when interstitial ad is closed
        interstitialAd.OnAdLoaded -= this.HandleOnAdLoaded;
        interstitialAd.OnAdOpening -= this.HandleOnAdOpening;
        interstitialAd.OnAdClosed -= this.HandleOnAdClosed;

        RequestInterstitialAd(); //request new interstitial ad after close
    }

    public void DestroyInterstitialAd()
    {
        interstitialAd.Destroy();
    }

    public void RequestBannerAd()
    {
        adBanner = new BannerView(adBannerId, AdSize.Banner, AdPosition.Top);
        AdRequest request = new AdRequest.Builder().Build();
        adBanner.LoadAd(request);
    }

    public void DestroyBannerAd()
    {
        if (adBanner != null)
            adBanner.Destroy();
    }

    public void OnMoreStarsClicked()
    {
        BtnReward.interactable = false;
        btnPlayAgain.interactable = false;
        btnReturnMenu.interactable = false;
        BtnReward.GetComponentInChildren<Text>().text = "Loading...";
        RequestRewardAd();
    }

    public void RequestRewardAd()
    {
        AdRequest request = new AdRequest.Builder().Build();
        rewardedAd.LoadAd(request, adUnitId);

        rewardedAd.OnAdLoaded += this.HandleOnRewardedAdLoaded;
        rewardedAd.OnAdRewarded += this.HandleOnAdRewarded;
        rewardedAd.OnAdClosed += this.HandleOnRewardedAdClosed;
    }


    public void ShowRewardAd()
    {
        if (rewardedAd.IsLoaded())
            rewardedAd.Show();
    }

    public void HandleOnRewardedAdLoaded(object sender, EventArgs args)
    {
        ShowRewardAd();

    }

    public void HandleOnAdRewarded(object sender, EventArgs args)
    {
        if (alreadyWatchAds == false)
        {
            int starsAmount = collectable.getStarsAmount();
            saveStars.addStars(starsAmount);
            starsEanred.text = (starsAmount + starsAmount).ToString();
            alreadyWatchAds = true;
        }


    }

    public void HandleOnRewardedAdClosed(object sender, EventArgs args)
    {
        BtnReward.interactable = false;
        btnPlayAgain.interactable = true;
        btnReturnMenu.interactable = true;
        BtnReward.GetComponentInChildren<Text>().text = "Reward redeemed!";
        rewardedAd.OnAdLoaded -= this.HandleOnRewardedAdLoaded;
        rewardedAd.OnAdRewarded -= this.HandleOnAdRewarded;
        rewardedAd.OnAdClosed -= this.HandleOnRewardedAdClosed;
    }

    private void OnDestroy()
    {
        rewardedAd.OnAdLoaded -= this.HandleOnRewardedAdLoaded;
        rewardedAd.OnAdRewarded -= this.HandleOnAdRewarded;
        rewardedAd.OnAdClosed -= this.HandleOnRewardedAdClosed;
        DestroyBannerAd();
        DestroyInterstitialAd();

        interstitialAd.OnAdLoaded -= this.HandleOnAdLoaded;
        interstitialAd.OnAdOpening -= this.HandleOnAdOpening;
        interstitialAd.OnAdClosed -= this.HandleOnAdClosed;
    }

}
