using UnityEngine;

public class MobilePlatformChecker : MonoBehaviour
{
    [SerializeField] private GameObject _mobileInput;

    private void Awake()
    {
        if (Application.isMobilePlatform)
        {
            var mobileInput = Instantiate(_mobileInput, transform);
            mobileInput.transform.SetAsFirstSibling();
        }
    }
}
