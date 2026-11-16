using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class CombatProjectile : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float lifetime = 5f;
    public float damageValue = 50f;
    public GameObject deathDecal;
    public GameObject deathDecalHit;
    public GameObject projectileOwner;
    
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().linearVelocity = moveSpeed * gameObject.transform.forward;
        Destroy(gameObject,lifetime);
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Projectile hit on " + other.gameObject.name);
        CombatController tank = other.gameObject.GetComponentInParent<CombatController>();
        if(tank)
        {
            tank.GetComponent<CombatController>().TakeDamage(damageValue,projectileOwner);
            Instantiate(deathDecalHit, gameObject.transform.position,
               gameObject.transform.rotation);
        }
        else
        {
            Instantiate(deathDecal, gameObject.transform.position,
               gameObject.transform.rotation);
        }
        Destroy(gameObject);
        
    }


}
