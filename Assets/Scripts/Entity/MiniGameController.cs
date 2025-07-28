using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameEndHandler : MonoBehaviour
{
    public int score;
    public string M_sceneName = "scene";
    public void EndGame()
    {
        ScoreManager.Instance.SaveHighScore(); // 최고 점수 저장
        PlayerPrefs.SetInt("LastScore", ScoreManager.Instance.score); // 현재 점수 저장
        PlayerPrefs.Save();

        SceneManager.LoadScene(M_sceneName); // 메인맵 복귀
    }

    void Start()
    {
        int lastScore = PlayerPrefs.GetInt("LastScore", 0);
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        Debug.Log("마지막 점수: " + lastScore);
        Debug.Log("최고 점수: " + highScore);
    }
}