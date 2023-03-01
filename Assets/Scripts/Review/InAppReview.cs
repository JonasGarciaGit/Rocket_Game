using Google.Play.Review;
using System.Collections;
using UnityEngine;

public class InAppReview : MonoBehaviour
{
    private ReviewManager _reviewManager;
    private PlayReviewInfo _playReviewInfo;
    int launchCount;


    // Start is called before the first frame update
    void Start()
    {
        launchCount = PlayerPrefs.GetInt("TimesLaunched", 0);

        launchCount = launchCount + 1;
        PlayerPrefs.SetInt("TimesLaunched", launchCount);

        if (launchCount == 5 || launchCount == 10 || launchCount == 15 || launchCount == 20 || launchCount == 25)
        {
            StartCoroutine(RequestReviewsAsync());
        }

    }

    IEnumerator RequestReviewsAsync()
    {
        _reviewManager = new ReviewManager();

        //Request a ReviewInfo Object

        var requestFlowOperation = _reviewManager.RequestReviewFlow();
        yield return requestFlowOperation;
        if (requestFlowOperation.Error != ReviewErrorCode.NoError)
        {
            // Log error. For example, using requestFlowOperation.Error.ToString().
            yield break;
        }
        _playReviewInfo = requestFlowOperation.GetResult();

        //Launch the InApp Review Flow

        var launchFlowOperation = _reviewManager.LaunchReviewFlow(_playReviewInfo);
        yield return launchFlowOperation;
        _playReviewInfo = null; // Reset the object

        if (launchFlowOperation.Error != ReviewErrorCode.NoError)
        {
            // Log error. For example, using requestFlowOperation.Error.ToString().
            yield break;
        }

        // The flow has finished. The API does not indicate whether the user
        // reviewed or not, or even whether the review dialog was shown. Thus, no
        // matter the result, we continue our app flow.
    }
}
