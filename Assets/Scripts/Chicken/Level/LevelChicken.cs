using UnityEngine;
using UnityEngine.UI;

public class LevelChicken : MonoBehaviour, IAddLevel
{
    public int LevelPoint { get; private set; }
    public int Level;

    public AudioSource LevelUpgarade;

    public delegate void LevelHandler(int newValue);
    public event LevelHandler OnLevelValueChangedEvent;

    [SerializeField] private BankScors _bankScors;

    public LevelChicken(BankScors _bankScors)
    { 
        this._bankScors = _bankScors;
    }

    void IAddLevel.AddLevelPoint(int levelPoint)
    {
        LevelPoint += levelPoint;
        if (LevelPoint >= 100)
                LevelUp();

        OnLevelValueChangedEvent?.Invoke(this.LevelPoint);
    }
    public void LevelUp()
    {
            LevelUpgarade.Play();
            Level += 1;
            _bankScors.AddScore(1);
            LevelPoint -= 100;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            _bankScors.AddScore(3000);
        }
    }
}
