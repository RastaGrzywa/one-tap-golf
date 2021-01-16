using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text finishScoreText;
    [SerializeField] private Text finishBestText;
    [SerializeField] private GameObject finishGameScreen;
    [SerializeField] private Transform ballStartingPoint;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject holeObject;
    [SerializeField] private List<FailObject> failObjects;
    
    private int _currentScore;
    private int _bestScore;
    private float _basePowerIncreaseRate = 3f;
    private float _currentPowerIncreaseRate;
    public float currentPowerIncreaseRate => _currentPowerIncreaseRate;
    
    private GameObject _ballObject;
    
    private static GameManager _instance;
    public static GameManager Instance => _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        } else {
            _instance = this;
        }
    }
    
    void Start()
    {
        _currentPowerIncreaseRate = _basePowerIncreaseRate;
        UpdateUI();
        SetupNewLevel();
    }

    private void SetupNewLevel()
    {
        if (_ballObject == null)
        {
            _ballObject = Instantiate(ballPrefab);
        }
        _ballObject.SetActive(false);
        _ballObject.transform.position = ballStartingPoint.position;
        _ballObject.SetActive(true);

        float randomHoleXPosition = Random.Range(-5f, 5f);
        Vector3 newHolePosition = holeObject.transform.position;
        newHolePosition.x = randomHoleXPosition;
        holeObject.transform.position = newHolePosition;
        EnableFail(false);
    }

    private void UpdateUI()
    {
        scoreText.text = _currentScore.ToString();
    }

    public void FinishLevel()
    {
        _currentScore++;
        _currentPowerIncreaseRate += 0.2f;
        UpdateUI();
        SetupNewLevel();
    }

    public void FailLevel()
    {
        if (_currentScore > _bestScore)
        {
            _bestScore = _currentScore;
        }

        finishScoreText.text = "SCORE: " + _currentScore;
        finishBestText.text = "BEST: " + _bestScore;
        
        finishGameScreen.SetActive(true);
        Destroy(_ballObject);
    }

    public void EnableFail(bool enabled)
    {
        foreach (var item in failObjects)
        {
            item.EnableFail(enabled);
        }
    }

    public void HandleResetButton()
    {
        finishGameScreen.SetActive(false);
        _currentPowerIncreaseRate = _basePowerIncreaseRate;
        _currentScore = 0;
        SetupNewLevel();
        UpdateUI();
    }

    public void HandleExitButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
