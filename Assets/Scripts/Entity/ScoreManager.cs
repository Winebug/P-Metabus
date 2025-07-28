using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance 
    { 
        get; 
        private set; 
    }

    public int score = 0;
    public Text scoreText;
    public string M_sceneName = "scene";

    void Awake()
    {
        // 인스턴스가 없으면 자신을 할당
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시 파괴되지 않도록 설정
        }
        else
        {
            Destroy(gameObject); // 중복 방지
        }
    }

    void Start()
    {
        UpdateScoreUI();
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = $"점수: {score}";
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreUI();
    }

    public void SaveHighScore()
    {
        int bestScore = PlayerPrefs.GetInt("HighScore", 0); // 저장된 최고 점수 불러오기

        if (score > bestScore)
        {
            PlayerPrefs.SetInt("HighScore", score); // 최고 점수 갱신
            PlayerPrefs.Save(); // 즉시 저장
        }
    }

    public class ScoreUI : MonoBehaviour
    {
        public Text scoreText;

        void Update()
        {
            scoreText.text = "점수: " + ScoreManager.Instance.score.ToString();
        }
    }

    public void EndGame()
    {
        ScoreManager.Instance.SaveHighScore(); // 최고 점수 저장
        PlayerPrefs.SetInt("LastScore", ScoreManager.Instance.score); // 현재 점수 저장
        PlayerPrefs.Save();
        SceneManager.LoadScene(M_sceneName); // 메인맵 복귀
    }

}