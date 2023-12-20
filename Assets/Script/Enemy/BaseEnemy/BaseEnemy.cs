using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour, IDamageble
{

    public IAddLevel IAddLevel;

    private GameObject _chiken;

    public int MaxHP;
    public float CurrentHP;
    public int Exp;
    public int Level;


    private void Awake()
    {
        _chiken = GameObject.Find("ToonChicken");
        LevelChicken level = _chiken.GetComponent<LevelChicken>();
        IAddLevel = level.GetComponent<IAddLevel>();
    }
    public void Damage(float damage)
    {
        CurrentHP -= damage;

        if (CurrentHP <= 0)
        {
            Destroy(this);
            IAddLevel.AddLevelPoint(Exp);
            EffectController.Instance.SetClickEffect(Exp);
        }
    }
}
