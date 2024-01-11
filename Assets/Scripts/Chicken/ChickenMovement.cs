using UnityEngine;

public class ChickenMovement
{
    private AudioSource _chikenStep;
    private Joystick _joystick;

    private ChickenStats _speedStats;

    private Vector3 _moveVector;
    public float Speed => _speedStats.Value;

    public ChickenMovement(AudioSource chikenStep, Joystick joystick, ChickenStats speedStats)
    {
        _chikenStep = chikenStep;
        _joystick = joystick;
        _speedStats = speedStats;
    }
    public Vector3 MoveVector()
    {
        _moveVector = new Vector3(_joystick.Horizontal * Speed, 0, _joystick.Vertical * Speed);
        if (_moveVector.x != 0 || _moveVector.z != 0)
            _chikenStep.enabled = true;
        else _chikenStep.enabled = false;
      
        return _moveVector;
    }
}
