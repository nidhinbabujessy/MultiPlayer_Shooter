
using UnityEngine;

public class gun : MonoBehaviour
{
    public Camera fpsCam;
    public float damage = 10f;
    public float range = 100f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Change "Fire1" to the name of your button input
        {
            Shoot();
        }
    }


    public void Shoot()
    {
    
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position,fpsCam.transform.forward,out hit,range ))
            {
            EnemyDie enemyDie = hit.transform.GetComponent<EnemyDie>();
            {
                if(enemyDie != null)
                {
                    enemyDie.TakeDamage(damage);
                }
            }
        }
    }
}
