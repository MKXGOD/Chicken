using UnityEngine;
using TMPro;

public class UpgradeStats : MonoBehaviour
{
    public TextMeshProUGUI Value;
    public void SetData(ChickenStats chickenStats)
    {
        Value.text = "" + chickenStats.Value;
    }
}
