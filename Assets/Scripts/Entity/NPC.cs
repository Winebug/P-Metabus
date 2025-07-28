using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC : MonoBehaviour
{
    public string sceneName = "Flappy";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("플레이어와 충돌! 미니게임 로딩 중...");
            SceneManager.LoadScene(sceneName);
        }
    }
}
