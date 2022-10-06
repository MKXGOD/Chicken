using UnityEngine;

public class ChickenController : MonoBehaviour
{
    public Chicken Chicken;
    public Vector3 _moveVector;

    public Joystick Joystick;

    public AudioSource ChickenStep;

    private CharacterController _ch_control;

    void Start()
    {
        _ch_control = GetComponent<CharacterController>();
       
    }
    void Update()
    {
        CharacterMove();
    }

    private void CharacterMove()
    {
        _moveVector = Vector3.zero;
        _moveVector.x = Joystick.Horizontal * Chicken.Speed();
        _moveVector.z = Joystick.Vertical * Chicken.Speed();

        _ch_control.Move(_moveVector * Time.deltaTime);

        if (_moveVector == new Vector3(0,0,0))
        { 
            ChickenStep.Play();
        }

        if (Vector3.Angle(Vector3.forward, _moveVector) > 1f || Vector3.Angle(Vector3.forward, _moveVector) == 0)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, _moveVector, Chicken.Speed(), 0.0f);
            transform.rotation = Quaternion.LookRotation(direct);
        }
    }
}
