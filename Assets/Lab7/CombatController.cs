using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    public float movespeed = 10;
    public float rotationrate = 180;
    public int playerInputNumber = 1;

    InputData input;
    Rigidbody rb;
    Vector3 startingLocation;
    Quaternion startingRotation;
    bool Fire1IsEnabled = true;
    bool Fire2IsEnabled = true;
    public GameObject projectilePrefab;
    public GameObject projectileSpawnPoint;
    public GameObject deathDecal;
    public GameObject rayDecal;
    public LaserControler laser;
    public AudioClip soundBap;
    public AudioClip soundPew;
    private AudioSource audioSource;
    public float pitchFloor;
    public float pitchRange;
    public float kills;
    public float deaths;
    public float kdRatio;
    public float health = 100f;
    public float raydamage = 100f;
    public float rayDistance = 50f;
    public bool debugLine = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        startingLocation = gameObject.transform.position;
        startingRotation = gameObject.transform.rotation;
        audioSource = gameObject.AddComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        input = InputPoller.reference.GetInput(playerInputNumber);

        MovePlayer(input.leftStick.y);

        RotatePlayer(input.leftStick.x);

        if (Fire1IsEnabled && input.buttonNorth)
        { Fire1(); }

        if (Fire2IsEnabled && input.buttonEast)
        { Fire2(); }
        if (debugLine)
        {
            RaycastLine();
        }
    }
    void MovePlayer(float value)
    {
      rb.linearVelocity = value * movespeed * gameObject.transform.forward;
    }

    void RotatePlayer(float value)
    {
        gameObject.transform.Rotate(rotationrate * Time.deltaTime * value * Vector3.up);
    }

    public void Fire1()
    {
        audioSource.PlayOneShot(soundBap);
        ProjectileFire();
        
    }

    public void Fire2()
    {
        audioSource.PlayOneShot(soundPew);
        PerformRaycast();
    }

    public void ProjectileFire()
    {
        GameObject newProjectile = Instantiate(projectilePrefab, projectileSpawnPoint.transform.position,
                    projectileSpawnPoint.transform.rotation);
        CombatProjectile cp = newProjectile.GetComponent<CombatProjectile>();
        cp.projectileOwner = gameObject;
    }
    
    public void PerformRaycast()
    {
        Vector3 originPoint = projectileSpawnPoint.transform.position;
        Vector3 destinationPoint = projectileSpawnPoint.transform.forward;
        RaycastHit hit;
        bool hashit = Physics.Raycast(originPoint, destinationPoint,out hit, rayDistance);
        
        if (hashit)
        {
            Debug.Log("Raycast hit on " + hit.collider.gameObject.name);
            CombatController tank = hit.collider.gameObject.GetComponentInParent<CombatController>();
            laser.FireLaser(hit.distance);
            if (tank)
            {
                Instantiate(rayDecal, tank.gameObject.transform.position, tank.gameObject.transform.rotation);
                tank.GetComponent<CombatController>().TakeDamage(raydamage,gameObject);
            }
        }
        
    }

    public void Restart()
    {
        Instantiate(deathDecal,gameObject.transform.position,gameObject.transform.rotation);
        gameObject.transform.position = startingLocation;
        gameObject.transform.rotation = startingRotation;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
    public void RaycastLine()
    {

        Vector3 originPoint = projectileSpawnPoint.transform.position;
        Vector3 destinationPoint = projectileSpawnPoint.transform.forward * rayDistance;
        Debug.DrawRay(originPoint, destinationPoint, Color.red);

    }
    
    public void GotKill()
    {
        kills += 1;
        if (deaths == 0)
        { kdRatio = kills/1; }
        else
        { kdRatio = kills / deaths; }

    }
    public void TakeDamage(float damage, GameObject player)
    {
        health -= damage;
        if (health <= 0f)
        {
            player.GetComponent<CombatController>().GotKill();
            deaths += 1;
            kdRatio = kills / deaths;

            Restart();
            health = 100f;

        }
    }





}