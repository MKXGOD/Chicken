using System.Collections;
using UnityEngine;

public class HitMarker : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private float _hitDuration;

    private string _hexDefaultColor = "#FFFFFF";
    private string _hexHitColor = "#FF0202";

    private Coroutine _hitRoutine;
    private void SetMaterialColor(string hex)
    {
        if (ColorUtility.TryParseHtmlString(hex, out Color currentColor))
        {
            _renderer.material.color = currentColor;
        }
    }
    private IEnumerator HitRoutine()
    { 
        SetMaterialColor(_hexHitColor);
        yield return new WaitForSeconds(_hitDuration);
        SetMaterialColor(_hexDefaultColor);
        _hitRoutine = null;

    }
    public void HitMark()
    {
        if (_hitRoutine != null)
        {
            StopCoroutine(HitRoutine());
        }

        _hitRoutine = StartCoroutine(HitRoutine());
    }
}
