namespace _Main._Resources.Scripts.Utilities
{
    public class HealthController
    {
        //Campos

        int _currentHealth;
        int _currentMaxHealth;

        //Properties
        public int Health
        {
            get
            {
                return _currentHealth;
            }
            set
            {
                _currentHealth = value;
            }
        }


        public int MaxHealth
        {
            get
            {
                return _currentMaxHealth;
            }
            set
            {
                _currentMaxHealth = value;
            }
     

        }

        //Constructor
        public HealthController(int health, int maxHealth)
        {
            _currentHealth = health;
            _currentMaxHealth = maxHealth;
        }


        // Methods
        public void Heal (int healAmount)
        {
            if (_currentHealth < _currentMaxHealth)
            {
                _currentHealth += healAmount;
            }
            if (_currentHealth > _currentMaxHealth)
            {
                _currentHealth = _currentMaxHealth;
            }

         
        }

        public void Damage( int damageAmount)
        {
            if (_currentHealth > 0)
            {
                _currentHealth -= damageAmount;
            }
        }

    }
}
