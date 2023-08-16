using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public string myGameIdAndroid = "5374090";
    public string myGameIdIOS = "5374091";

    public string adUnitId_Rewarded_Android = "Rewarded_Android";
    public string adUnitId_Rewarded_IOS = "Rewarded_iOS";

    public string adUnitId_Interstitial_Android = "Interstitial_Android";
    public string adUnitId_Interstitial_IOS = "Interstitial_iOS";

    public string adUnitId_Banner_Android = "Banner_Android";
    public string adUnitId_Banner_IOS = "Banner_iOS";

    public string myAdUnitId;
    public bool adStarted;

    private bool testMode = true;

    // Start is called before the first frame update
    void Start()
    {
        #if UNITY_IOS
	        Advertisement.Initialize(myGameIdIOS, testMode);
	        myAdUnitId = adUnitIdIOS;
        #else
            Advertisement.Initialize(myGameIdAndroid, testMode);
            myAdUnitId = adUnitId_Banner_Android;
        #endif

        Debug.Log("My unity ID is:" + myAdUnitId);
    }

    // Update is called once per frame
    void Update()
    {
        if (Advertisement.isInitialized && !adStarted)
        {
            LoadAd();
            ShowAd();
            adStarted = true;
        }

    }

    // Load content to the Ad Unit:
    public void LoadAd()
    {
        // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
        Debug.Log("Loading Ad: " + myAdUnitId);
        Advertisement.Load(myAdUnitId, this);
    }

    // Show the loaded content in the Ad Unit:
    public void ShowAd()
    {
        // Note that if the ad content wasn't previously loaded, this method will fail
        Debug.Log("Showing Ad: " + myAdUnitId);
        Advertisement.Show(myAdUnitId, this);
    }

    // Implement Load Listener and Show Listener interface methods: 
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        // Optionally execute code if the Ad Unit successfully loads content.
        Debug.Log("Ad unit:" + adUnitId + " is loaded succesfully!");
    }

    public void OnUnityAdsFailedToLoad(string _adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit: {_adUnitId} - {error.ToString()} - {message}");
        // Optionally execute code if the Ad Unit fails to load, such as attempting to try again.
        Debug.Log("Ad unit:" + myAdUnitId + " is failed to load...");
    }

    public void OnUnityAdsShowFailure(string _adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {_adUnitId}: {error.ToString()} - {message}");
        // Optionally execute code if the Ad Unit fails to show, such as loading another ad.
    }

    public void OnUnityAdsShowStart(string _adUnitId) 
    {
        Debug.Log("Ad unit:" + _adUnitId + " show started!");
    }
    public void OnUnityAdsShowClick(string _adUnitId) 
    {
        Debug.Log("Ad unit:" + _adUnitId + " show is clicked!");
    }
    public void OnUnityAdsShowComplete(string _adUnitId, UnityAdsShowCompletionState showCompletionState) 
    {
        Debug.Log("Ad unit:" + _adUnitId + " show is complete!");
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }
}