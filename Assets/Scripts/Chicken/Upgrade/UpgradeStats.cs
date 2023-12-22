using UnityEngine;
using UnityEngine.UI;

public class UpgradeStats : MonoBehaviour
{
    public Text Value;

    private ChickenStats _chickenStats;
    [SerializeField]private BankScors _bankScors;
    private CanvasGroup _canvasGroup;


    public void SetData(ChickenStats _chickenStats)
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        this._chickenStats = _chickenStats;
        UpdateUI();
    }

    public void UpdateUI()
    {
        Value.text = "" + _chickenStats.Level;
        _canvasGroup.alpha = _bankScors.Score >= _chickenStats.Price ? 1 : 5f;
    }

    public void BuyUpgrade()
    {
        if (_bankScors.Score < _chickenStats.Price)
            return;

        _bankScors.SpendScore(_chickenStats.Price);
        _chickenStats.LevelUp();
        UpdateUI();

        Debug.Log("Buy");
        Debug.Log(_bankScors.Score);
    }
}
