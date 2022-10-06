using UnityEngine;

public class BankScors : MonoBehaviour
{
    public float Score { get; private set; }

    public void AddScore(float value)
    {
        Score += value;
    }

    public void SpendScore(float value)
    { 
        Score -= value;
    }
}
