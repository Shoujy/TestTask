using UnityEngine;

public class Currency
{
    public string Name { get; private set; }
    public int Value { get; private set; }

    public Currency(string name, int value)
    {
        Name = name;
        Value = value;
    }

    public void Deposit(int amount)
    {
        if(amount >= 0)
        {
            Value += amount;
            Debug.Log($"You Successfully deposit [{amount}] of [{Name}] to your Bag");
        }
        else
        {
            Debug.Log($"Deposit can't be negative!");
        }
    }

    public void Withdraw(int amount)
    {
        if((Value - amount) >= 0)
        {
            Value -= amount;
            Debug.Log($"You successfully withdraw [{amount}] of your [{Name}]");
        }
        else
        {
            Debug.Log($"You do not have enough of [{Name}] in your Bag");
        }
    }
}