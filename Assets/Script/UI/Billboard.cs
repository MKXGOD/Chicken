using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform _camera;
    private void Start()
    {
        _camera = GameObject.Find("Main Camera").GetComponent<Transform>();
    }
    private void Update()
    {
        transform.LookAt(transform.position + _camera.forward);
    }
}
