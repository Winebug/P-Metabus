using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC : MonoBehaviour
{
    public string sceneName = "Flappy";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("�÷��̾�� �浹! �̴ϰ��� �ε� ��...");
            SceneManager.LoadScene(sceneName);
        }
    }
}
