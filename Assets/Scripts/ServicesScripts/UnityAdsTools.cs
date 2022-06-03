using System;
using UnityEngine;
using UnityEngine.Advertisements;
namespace Tools
{
    internal class UnityAdsTools : MonoBehaviour, IAdsShower, /*IUnityAdsListener*/ IUnityAdsShowListener
    {
        #region Fields
        private string _gameId = "4697777";
        private string _rewardPlace = "SpeedUpMaxUnit";
        private string _interstitialPlace = "123";
        private Action _callbackSuccessShowVideo;
        #endregion
        private void Start()
        {
            Advertisement.Initialize(_gameId, true);
        }
        #region IAdsShower
        public void ShowInterstitial()
        {
            _callbackSuccessShowVideo = null;
            Advertisement.Show(_interstitialPlace);
        }
        public void ShowVideo(Action successShow)
        {
            _callbackSuccessShowVideo = successShow;
            Advertisement.Show(_rewardPlace);
        }
        #endregion
        public void OnUnityAdsReady(string placementId)
        {
        }
        public void OnUnityAdsDidError(string message)
        {
        }
        public void OnUnityAdsDidStart(string placementId)
        {
        }
        public void OnUnityAdsDidFinish(string placementId, ShowResult
        showResult)
        {
            if (showResult == ShowResult.Finished)
                _callbackSuccessShowVideo?.Invoke();
        }
        #region IUnityAdsShowListener
        public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
        {
            throw new NotImplementedException();
        }
        public void OnUnityAdsShowStart(string placementId)
        {
            throw new NotImplementedException();
        }
        public void OnUnityAdsShowClick(string placementId)
        {

        }
        public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
        {
            if (showCompletionState == UnityAdsShowCompletionState.COMPLETED)
                _callbackSuccessShowVideo?.Invoke();


        }
        #endregion
    }
}