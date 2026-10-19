using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Breach : MonoBehaviour
{
    private bool isPlayerInside = false;
    private bool isActivated = false;

    void Update()
    {
        Keyboard kb = Keyboard.current;
        if (isPlayerInside && kb.eKey.wasPressedThisFrame && !isActivated && kb != null)
        {
            isActivated = true;
            StartCoroutine(BlockAndDestroyRoutine());
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
}
