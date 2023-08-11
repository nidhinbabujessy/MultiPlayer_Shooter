
using UnityEngine;

public class gun : MonoBehaviour
{
    public Camera fpsCam;
    public float damage = 10f;
    public float range = 100f;
    public ParticleSystem mucleFlash;
    public GameObject fireEffect;

    // animation
    public Animator Aplayer;

    void Update()
    {
    }


    public void Shoot()
    {
        mucleFlash.Play();
        Aplayer.Play("ShootAutoshot_AR_Anim");

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
            Instantiate(fireEffect,hit.point,Quaternion.LookRotation(hit.normal));
        }
    }
}
