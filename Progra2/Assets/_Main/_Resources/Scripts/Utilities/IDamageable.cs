namespace _Main._Resources.Scripts.Utilities
{
    public interface IDamageable 
    {
    // Stuff.
    
    int Health { get; set; }
    void Damage(int damage);

    }
}
