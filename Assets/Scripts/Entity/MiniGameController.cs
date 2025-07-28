using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameEndHandler : MonoBehaviour
{
    public int score;
    public string M_sceneName = "scene";
    public void EndGame()
    {
        ScoreManager.Instance.SaveHighScore(); // �ְ� ���� ����
        PlayerPrefs.SetInt("LastScore", ScoreManager.Instance.score); // ���� ���� ����
        PlayerPrefs.Save();

        SceneManager.LoadScene(M_sceneName); // ���θ� ����
    }

    void Start()
    {
        int lastScore = PlayerPrefs.GetInt("LastScore", 0);
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        Debug.Log("������ ����: " + lastScore);
        Debug.Log("�ְ� ����: " + highScore);
    }
}