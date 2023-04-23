using System;
using System.Collections.Generic;
using UnityEngine;

public class MoneyBag
{
    private List<Currency> _currencies;

    public static Action<int> OnCurrencyAmountChanged;

    public MoneyBag()
    {
        _currencies = new List<Currency>();
    }

    public void AddCurrency(Currency currency)
    {
        Currency existingCurrency = _currencies.Find(c => c.GetType() == currency.GetType());

        if (existingCurrency != null)
        {
            existingCurrency.Deposit(currency.Value);
            OnCurrencyAmountChanged?.Invoke(GetCurrentAmount(currency));
        }
        else
        {
            _currencies.Add(currency);
            OnCurrencyAmountChanged?.Invoke(GetCurrentAmount(currency));
        }
    }

    public void RemoveCurrency(Currency currency)
    {
        Currency existingCurrency = _currencies.Find(c => c.GetType() == currency.GetType());

        if (existingCurrency != null)
        {
            existingCurrency.Withdraw(currency.Value);
            OnCurrencyAmountChanged?.Invoke(GetCurrentAmount(currency));
        }
        else
        {
            Debug.Log($"Currency with name: [{currency.Name}] do not exist");
        }
    }

    public int GetCurrentAmount(Currency currency)
    {
        Currency existingCurrency = _currencies.Find(c => c.GetType() == currency.GetType());

        if (existingCurrency != null)
        {
            return existingCurrency.Value;
        }
        else
        {
            return 0;
        }
    }

    public bool CanAfford(Currency currency, int price)
    {
        Currency existingCurrency = _currencies.Find(c => c.GetType() == currency.GetType());

        if(existingCurrency != null && existingCurrency.Value >= price)
        {
            return true;
        }

        return false;
    }
}
