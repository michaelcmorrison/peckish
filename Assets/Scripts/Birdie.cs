using UnityEngine;

public class Birdie : MonoBehaviour, IDamageable
{
    public static bool IsFlying { get; set; }
    public int startingLives;
    public int lives;
    public float maxHunger;
    public Hunger hunger;

    private void Start()
    {
        hunger = new Hunger(maxHunger);
        lives = startingLives;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Enemy"))
        {
            var enemy = other.gameObject.GetComponent<IDamage>();
            TakeDamage(enemy.DamageAmount);
            if (lives <= 0)
            {
                GameManager.Instance.TriggerEndGame();
            }
        }
    }

    public void TakeDamage(int amount)
    {
        lives -= amount;
    }
}