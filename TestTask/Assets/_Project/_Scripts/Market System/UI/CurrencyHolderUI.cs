using TMPro;
using UnityEngine;

public class CurrencyHolderUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currencyAmount;

    private void OnEnable()
    {
        MoneyBag.OnCurrencyAmountChanged += UpdateAmount;
    }

    private void OnDisable()
    {
        MoneyBag.OnCurrencyAmountChanged -= UpdateAmount;
    }

    public void UpdateAmount(int currentAmount)
    {
        _currencyAmount.SetText(currentAmount.ToString());
    }
}
