using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class RewardedAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private int _maxHealth;

    private string _rewardedAdId = "Rewarded_Android";

    private void Start()
    {
        LoadAd();
    }

    private void LoadAd()
    {
        Advertisement.Load(_rewardedAdId, this);
    }

    public void ShowAd()
    {
        Advertisement.Show(_rewardedAdId, this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {

    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {

    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {

    }

    public void OnUnityAdsShowStart(string placementId)
    {

    }

    public void OnUnityAdsShowClick(string placementId)
    {

    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        _playerData.SetPlayerMaxHealth(_maxHealth);
        SceneManager.LoadScene(0);
    }
}
