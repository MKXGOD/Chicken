using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour, IDamagebleEnemy
{

    public IAddLevel IAddLevel;

    private GameObject _chiken;

    public int MaxHP;
    public int CurrentHP;
    public int Exp;
    public int Level;


    private void Awake()
    {
        _chiken = GameObject.Find("ToonChicken");
        LevelChicken level = _chiken.GetComponent<LevelChicken>();
        IAddLevel = level.GetComponent<IAddLevel>();
    }
    public void Damage(int damage, GameObject Enemy)
    {
        CurrentHP -= damage;

        if (CurrentHP <= 0)
        {
            Destroy(Enemy);
            IAddLevel.AddLevelPoint(Exp);
            EffectController.Instance.SetClickEffect(Exp);
        }
    }
}
