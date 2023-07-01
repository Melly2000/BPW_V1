using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PlayerCombat : MonoBehaviour
{
    Pickup pickupScript;
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
    public bool isDead;
    int energyPickupCount = 1;
    SphereCollider colliderPlayer;
    
    void Start()
    {
        pickupScript = GetComponent<Pickup>();
        colliderPlayer = GetComponent<SphereCollider>();
        playerMovementScript = GetComponent<Player>();
        mouseMovementScript = GetComponent<MouseMovement>();
        enemyCombatScript = enemy.GetComponent<EnemyCombat>();
        currentEnergy = maxEnergy;
        useEnergy = 10;
        energySystem.SetMaxHealth(energySlider, maxEnergy);
    }

    void Update()
    {
        if (pickupScript.NumberOfPickups == energyPickupCount)
        {
            energyPickupCount++;
            energySystem.SetMaxHealth(energySlider, maxEnergy);
        }
        if (Input.GetKey("space"))
        {
            playerMovementScript.enabled = false;
            if (Input.GetKeyUp("w") && !isAttacking)
            {
                Debug.Log("Launch attack!");
                isAttacking = true;
                targetPosition = transform.position + transform.right * distance;
                currentPosition = transform.position;
                currentEnergy = currentEnergy - useEnergy;
                energySystem.SetEnergy(energySlider, currentEnergy);
                mouseMovementScript.enabled = false;

                Debug.Log("current: " + currentEnergy);
                Debug.Log("use: " + useEnergy);
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
        }

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        bool allEnemiesDead = enemies.All(enemy => enemy.GetComponent<EnemyCombat>().isDead);
        if (allEnemiesDead)
        {
            Debug.Log("Player WINS!");
        }
    }
    private void FixedUpdate()
    {
        MAXIMUM_ENERGY_TO_USE = Mathf.FloorToInt(currentEnergy * 0.8f);
        MINIMUM_ENERGY_TO_USE = 10;
        if (currentEnergy < MINIMUM_ENERGY_TO_USE)
        {
            MINIMUM_ENERGY_TO_USE = currentEnergy;
        }
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

        if (isAttacking && other.CompareTag("Enemy"))
        {
            var enemy = other.GetComponent<EnemyCombat>();
            enemy.TakeDamage(useEnergy);

            // enemyCombatScript.TakeDamage(useEnergy);
            currentEnergy += useEnergy + 10;
        }
    }
    public void TakeDamage(int damage)
    {
        currentEnergy -= damage;
        energySystem.SetEnergy(energySlider, currentEnergy);
    }
    public void GetEnergy(int energyAmount)
    {
        currentEnergy += energyAmount;
        energySystem.SetEnergy(energySlider, currentEnergy);
    }
}
