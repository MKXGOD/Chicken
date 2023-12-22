using UnityEngine;

public class ChickenBeak:MonoBehaviour
{
    [SerializeField] private AudioSource _audioPunch;

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.TryGetComponent(out IDamageble iDamageble))
        { 

            _audioPunch.Play();
            iDamageble.Damage(3);   
        }
    }
}
