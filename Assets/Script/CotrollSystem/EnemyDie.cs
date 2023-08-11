using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    public float health = 50f;
    public GameObject box;

   

  
    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health < 0f)
        {
            Die();
        }
    }
    void Die()
    {
        box.SetActive(true);
        Destroy(gameObject);
    }
}