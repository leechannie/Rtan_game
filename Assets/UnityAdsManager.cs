using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;
public class UnityAdsManager : MonoSingleton<UnityAdsManager>, IUnityAdsListener
{
    private const string android_game_id = "4230303";
    private const string ios_game_id = "4230302";
    private const string android_myPlacementId = "Rewarded_Android";
    private const string ios_myPlacementId = "Rewarded_iOS";
    private string myPlacementId;
    public void Start()
    {
        Initialize();
    }
    private void Initialize()
    {
        Advertisement.AddListener(this);
#if UNITY_ANDROID
        Advertisement.Initialize(android_game_id);
        myPlacementId = android_myPlacementId;
#elif UNITY_IOS
        Advertisement.Initialize(ios_game_id);
        myPlacementId = ios_myPlacementId;
#endif
    }
    private void OnDisable()
    {
        Advertisement.RemoveListener(this);
    }
    public void ShowAd()
    {
        StartCoroutine(ShowAdWhenReady());
    }
    IEnumerator ShowAdWhenReady()
    {
        while (!Advertisement.IsReady(myPlacementId))
        {
            yield return null;
        }
        Advertisement.Show(myPlacementId);
    }
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch (showResult)
        {
            case ShowResult.Failed:
                Debug.LogError("보상 처리 실패");
                break;
            case ShowResult.Skipped:
                Debug.Log("보상 처리 중도 이탈");
                break;
            case ShowResult.Finished:
                Debug.Log("보상 처리 완료");
                GameManager.I.RevivePlayer();
                break;
        }
    }
    public void OnUnityAdsReady(string placementId)
    {
        if (placementId == myPlacementId)
        {
            //  Advertisement.Show(myPlacementId);
        }
    }
    public void OnUnityAdsDidError(string message)
    {
        Debug.LogError("OnUnityAdsDidError :" + message);
    }
    public void OnUnityAdsDidStart(string placementId)
    {
        if (placementId == myPlacementId)
        {
            //  Advertisement.Show(myPlacementId);
        }
    }
}