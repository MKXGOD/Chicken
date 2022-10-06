using UnityEngine;
using UnityEngine.UI;

public class EffectScript : MonoBehaviour
{
    public Text Text;
    [SerializeField] private CanvasGroup _group;

    void Update()
    {
        _group.alpha = Mathf.Lerp(_group.alpha, 0, Time.deltaTime * 2);
        transform.position += Vector3.up * Time.deltaTime * 60;

        if (_group.alpha < .01f)
            Destroy(gameObject);
    }
    public void SetPosition(Vector2 position)
    {
        transform.position = position;
    }

    public void SetValue(int value)
    {
        Text.text = "+" + value + "EXP";
    }
}
