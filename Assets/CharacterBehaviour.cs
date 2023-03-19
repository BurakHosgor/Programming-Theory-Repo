using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    public class Character
{
    private float health;
    public float Health
    {
        get => health;
        set => health = Mathf.Max(value, 0f);
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        Debug.Log("Health: " + Health);
    }
}

public class Player : Character
{
    public void Heal(float amount)
    {
        Health += amount;
        Debug.Log("Player healed for: " + amount);
    }
}

public class Enemy : Character
{
    public void Attack(Character target, float damage)
    {
        target.TakeDamage(damage);
    }
}

public class Game : MonoBehaviour
{
    private Player player;
    private Enemy enemy;

    void Start()
    {
        player = new Player();
        player.Health = 100f;

        enemy = new Enemy();
        enemy.TakeDamage(10f);
        enemy.Attack(player, 20f);

        player.Heal(10f);
    }
}

}
