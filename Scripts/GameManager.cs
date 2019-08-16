using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    /* Constants */
    // Current game's difficulty, which affects win score
    private const int EASY = 0;
    private const int HARD = 1;

    // Winning score condition, depending on difficulty
    private const int EASY_WINSCORE = 4;
    private const int HARD_WINSCORE = 10;

    // PlayerPrefs Keys
    private const string EASY_HIGHSCORE_KEY = "EasyHighScore";
    private const string HARD_HIGHSCORE_KEY = "HardHighScore";


    public GameObject canvas; // win screen
    public int difficulty;
    public TextMeshProUGUI elapsedTimeText;
    public TextMeshProUGUI bestTimeText;

    private int score;
    private int winScore;
    private string playerPrefKey;
    private float startTime;
    private float endTime;
    private float elapsedTime;    

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        startTime = Time.time;
        if (difficulty == EASY)
        {
            winScore = EASY_WINSCORE;
            SetInitialHighScore(EASY_HIGHSCORE_KEY);
            playerPrefKey = EASY_HIGHSCORE_KEY;
        } else if (difficulty == HARD)
        {
            winScore = HARD_WINSCORE;
            SetInitialHighScore(HARD_HIGHSCORE_KEY);
            playerPrefKey = HARD_HIGHSCORE_KEY;
        }
    }

    void SetInitialHighScore(string key)
    {
        if (PlayerPrefs.GetFloat(key) == 0f)
        {
            PlayerPrefs.SetFloat(key, 99f);
        }
    }

    public void ScoreUp()
    {
        score++;
        if (score >= winScore)
        {
            Win();
        }
    }


    void Win()
    {
        // Get and display Elapsed Time
        endTime = Time.time;
        elapsedTime = Mathf.Round((endTime - startTime) * 1000.0f) / 1000.0f;
        elapsedTimeText.text = elapsedTime.ToString();

        // Show Win Screen UI
        canvas.SetActive(true);

        // Update High Score
        if (elapsedTime < PlayerPrefs.GetFloat(playerPrefKey))
        {
            PlayerPrefs.SetFloat(playerPrefKey, elapsedTime);
            bestTimeText.text = elapsedTime.ToString();
        } else
        {
            bestTimeText.text = PlayerPrefs.GetFloat(playerPrefKey).ToString();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void ResetHighScore(string playerPrefString)
    {
        PlayerPrefs.DeleteKey(playerPrefString);
        PlayerPrefs.SetFloat(playerPrefString, 99f);
    }

}
