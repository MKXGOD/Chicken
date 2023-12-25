public interface IDamageble
{
    public delegate void DeathHandler(int exp);
    public event DeathHandler OnDeath;
    void Damage(float damage);
}
