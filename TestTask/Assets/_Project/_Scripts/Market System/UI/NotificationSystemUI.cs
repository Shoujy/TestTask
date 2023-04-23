using TMPro;
using UnityEngine;
using DG.Tweening;

public class NotificationSystemUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _message;
    private void OnEnable()
    {
        DOTween.Init(true);

        SwordSeller.OnSellerNotificationTriggered += ShowNotification;
        SwordBuyer.OnBuyerNotificationTriggered += ShowNotification;
    }
    private void OnDisable()
    {
        SwordSeller.OnSellerNotificationTriggered -= ShowNotification;
        SwordBuyer.OnBuyerNotificationTriggered -= ShowNotification;
    }

    public void ShowNotification(string message)
    {
        var newMessage = Instantiate(_message, transform);
        newMessage.SetText(message);

        newMessage.rectTransform.DOAnchorPosY(30f, 2.0f);
        newMessage.DOFade(0.5f, 2.0f);

        Destroy(newMessage.gameObject, 2.5f);
    }
}
