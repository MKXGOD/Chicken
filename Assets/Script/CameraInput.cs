using UnityEngine;

public class CameraInput : MonoBehaviour
{
    public Transform Chicken;
    public float Smooth = 2f;
    public Vector3 Offset = new Vector3(0, 2, -0.2f);
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Chicken.position + Offset, Time.deltaTime * Smooth);
    }
}
