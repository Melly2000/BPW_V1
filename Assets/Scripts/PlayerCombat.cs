using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCombat : MonoBehaviour
{
    public GameManager gameManager;
    [SerializeField] float distance = 500;
    public EnemyCombat enemyCombatScript;
    public GameObject enemy;
    private float step;
    Player playerMovementScript;
    MouseMovement mouseMovementScript;
    public int useEnergy = 10;
    public int maxEnergy = 50;
    public int currentEnergy;
    private int MAXIMUM_ENERGY_TO_USE;
    private int MINIMUM_ENERGY_TO_USE;
    public EnergyBar energySystem;
    private bool isAttacking = false;
    public Slider energySlider;
    public Slider UseEnergySlider;
    private Vector3 targetPosition, currentPosition;
    float timeElapsed;
    float lerpDuration = 2;
    private bool isDead;

    SphereCollider colliderPlayer;
    // Start is called before the first frame update
    void Start()
    {
        colliderPlayer = GetComponent<SphereCollider>();
        playerMovementScript = GetComponent<Player>();
        mouseMovementScript = GetComponent<MouseMovement>();
        enemyCombatScript = enemy.GetComponent<EnemyCombat>();
        currentEnergy = maxEnergy;
        energySystem.SetMaxHealth(energySlider, maxEnergy);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("space"))
        {
            playerMovementScript.enabled = false;
                Debug.Log(transform.right);
                Debug.Log(transform.position);
            if (Input.GetKeyUp("w") && !isAttacking)
            {
                Debug.Log("Launch attack!");
                isAttacking = true;
                // float actualDistance = distance = useEnergy; // Use energy to determine how far we go
                targetPosition = transform.position + transform.right * distance;
                currentPosition = transform.position;
                currentEnergy = currentEnergy - useEnergy;
                energySystem.SetEnergy(energySlider, currentEnergy);
                mouseMovementScript.enabled = false;
            }
        }
        else
        {
            playerMovementScript.enabled = true;
        }
        if (currentEnergy <= 0 && !isDead)
        {
            isDead = true;
            gameManager.GameOver();
            //Debug.Log("Enemy WINS!");
        }

    }
    private void FixedUpdate()
    {
        MAXIMUM_ENERGY_TO_USE = Mathf.FloorToInt(currentEnergy * 0.8f);
        MINIMUM_ENERGY_TO_USE = 10;

        if (Input.GetMouseButtonDown(1) && !isAttacking)
        {
            useEnergy = useEnergy - 1;
        }
        else if (Input.GetMouseButtonDown(0) && !isAttacking)
        {
            useEnergy = useEnergy + 1;
        }
        
        float clamped = Mathf.Clamp(useEnergy, MINIMUM_ENERGY_TO_USE, MAXIMUM_ENERGY_TO_USE);
        useEnergy = Mathf.FloorToInt(clamped);
        energySystem.SetEnergy(UseEnergySlider, useEnergy);

        if (isAttacking)
        {
            colliderPlayer.isTrigger = true;
            if (timeElapsed < lerpDuration)
            {
                transform.position = Vector3.Lerp(currentPosition, targetPosition, timeElapsed / lerpDuration);
                timeElapsed += Time.deltaTime;
            }
            else
            {
                isAttacking = false;
                colliderPlayer.isTrigger = false;
                timeElapsed = 0;
                mouseMovementScript.enabled = true;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("TRIGGERED!");
        // TODO: Check if collision is with enemy

        if (isAttacking && other.CompareTag("Enemy"))
        {
            // Debug.Log("HIT!");
            enemyCombatScript.TakeDamage(useEnergy);
            // Set energy back to useEnergy + 10
            currentEnergy += useEnergy + 10;
        }

    }
    // void OnCollisionEnter(Collision other)
    // {
    //     Debug.Log("TRIGGERED!");
    //     // TODO: Check if collision is with enemy

    //     if (isAttacking && CompareTag("Enemy"))
    //     {
    //         Debug.Log("HIT!");
    //         // Set energy back to useEnergy + 10
    //         currentEnergy += useEnergy + 10;
    //     }
    //     // else
    //     // {
    //     //     currentEnergy -= useEnergy;
    //     // }
    // }



    void UseEnergy()
    {

    }
    void LaunchAttack(Vector3 direction)
    {
        // Vector3 targetPosition;
        // targetPosition = new Vector3(direction.x + distance, transform.position.y, direction.y + distance);
        // huidige positie in richting transform.rotation + distance
        // transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        // Debug.Log("distance " + distance);
        var targetPosition = transform.right.normalized * 100 * distance;
        transform.position = Vector3.Lerp(transform.position, targetPosition, step);
        // Debug.Log(targetPosition);
        // Debug.Log(transform.position);
    }
    public void TakeDamage(int damage)
    {
        currentEnergy -= damage;
        energySystem.SetEnergy(energySlider, currentEnergy);
    }


}
