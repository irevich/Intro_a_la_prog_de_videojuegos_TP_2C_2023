
public class CmdAttack : ICommand
{
    private int _damage;
    private IDamageable _other;
    
    public CmdAttack(int damage, IDamageable other)
    {
        _damage = damage;
        _other = other;
    }
    
    public void Do()
    {
        _other.TakeDamage(_damage);
    }
}