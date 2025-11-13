using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("You Win!");
            // Reload level or show win screen
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
