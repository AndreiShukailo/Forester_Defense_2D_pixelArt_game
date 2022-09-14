using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAds : MonoBehaviour
{
    [SerializeField] private BannerPosition _bannerPosition;
    private string _bannerAdId = "Banner_Android";

    private void Start()
    {
        Advertisement.Banner.SetPosition(_bannerPosition);
        StartCoroutine(LoadAdBanner());
    }

    IEnumerator LoadAdBanner()
    {
        yield return new WaitForSeconds(2f);

        LoadBanner();
    }

    private void LoadBanner()
    {
        BannerLoadOptions options = new BannerLoadOptions
        {
            loadCallback = OnBannerLoaded,
            errorCallback = OnBannerError
        };

        Advertisement.Banner.Load(_bannerAdId, options);
    }

    private void OnBannerLoaded()
    {
        ShowBannerAdd();
    }

    private void OnBannerError(string message)
    {
        Debug.Log($"Banner Error: {message}");
    }

    private void ShowBannerAdd()
    {
        BannerOptions options = new BannerOptions
        {
            clickCallback = OnBannerClicker,
            hideCallback = OnBannerHidden,
            showCallback = OnBannerShown
        };

        Advertisement.Banner.Show(_bannerAdId, options);
    }


    private void OnBannerClicker() { }

    private void OnBannerHidden() { }

    private void OnBannerShown() { }
}
   
