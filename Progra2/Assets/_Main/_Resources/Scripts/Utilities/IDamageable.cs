namespace _Main._Resources.Scripts.Utilities
{
    public interface IDamageable
    {


        public int Health { get; set; }
        public void TakeDamage(int damage);

        public void Die();


    }
}
