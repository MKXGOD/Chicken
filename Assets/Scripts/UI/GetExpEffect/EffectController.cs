using UnityEngine;

public class EffectController : MonoBehaviour
{
    public static EffectController Instance;
    [SerializeField] private EffectScript _effectspref;

    private void Awake()
    {
        Instance = this;
    }

    public void SetClickEffect(int value)
    {
        var pref = Instantiate(_effectspref, transform, false);
        pref.SetPosition(new Vector2(Screen.width / 2, Screen.height / 2));
        pref.SetValue(value);
    }
}
