using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class Breach : MonoBehaviour
{   

    [SerializeField] private bool isPlayerInside = false;
    private bool isActiveProcess = false;

    [Header("Water config")]
    private WaterLvlManager waterLvlManager;
    private bool isLeaking = false;

    void Start()
    {
         waterLvlManager = FindAnyObjectByType<WaterLvlManager>();
         ActivateBreach();
    }

    void Update()
    {
        Keyboard kb = Keyboard.current;
        if (isPlayerInside && kb.eKey.wasPressedThisFrame && !isActiveProcess && kb != null)
        {
            isActiveProcess = true;
            StartCoroutine(BlockAndDestroyRoutine());
            Repair();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInside = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInside = false;
        }
    }

    IEnumerator BlockAndDestroyRoutine()
    {
        PlayerMove player = FindAnyObjectByType<PlayerMove>();
        if (player != null) player.canMove = false;
        yield return new WaitForSeconds(5);
        if (player != null) player.canMove = true;
        Destroy(transform.gameObject);
    }

    public void ActivateBreach()
    {
        if (!isLeaking)
        {
            isLeaking = true;
            if (waterLvlManager != null) waterLvlManager.AddBreach();
        }
    }
    public void Repair()
    {
        if (isLeaking)
        {
            isLeaking = false;
            if (waterLvlManager != null) waterLvlManager.RepairBreaches();
        }
    }
}
