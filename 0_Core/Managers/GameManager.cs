// 0_Core/Managers/GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Настройки времени")]
    [SerializeField] private float[] _gameSpeeds = { 1f, 2f, 3f };

    private int _currentSpeedIndex = 0;
    private bool _isPaused = false;


    public void TogglePause() => _isPaused = !_isPaused;

    // Менеджеры
    public TimeManager TimeManager { get; private set; }
    public ResourceManager ResourceManager { get; private set; }
    public ProvinceManager ProvinceManager { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        InitializeManagers();
    }

    private void InitializeManagers()
    {
        TimeManager = gameObject.AddComponent<TimeManager>();
        ResourceManager = gameObject.AddComponent<ResourceManager>();
        ProvinceManager = gameObject.AddComponent<ProvinceManager>();
    }



   

    public float CurrentSpeed
    {
        get
        {
            if (_isPaused) return 0f;

            if (_currentSpeedIndex < 0 || _currentSpeedIndex >= _gameSpeeds.Length)
            {
                Debug.LogError("Некорректный индекс скорости!");
                return 0f;
            }
            return _gameSpeeds[_currentSpeedIndex];
        }
    }
    public void SetNextSpeed()
    {
        if (_gameSpeeds.Length == 0)
        {
            Debug.LogError("Массив скоростей пуст!");
            return;
        }

        _currentSpeedIndex = (_currentSpeedIndex + 1) % _gameSpeeds.Length;
    }

    public void SetGameSpeed(int speedIndex)
    {
        if (speedIndex < 0 || speedIndex >= _gameSpeeds.Length)
        {
            Debug.LogError("Недопустимый индекс скорости!");
            return;
        }
        _currentSpeedIndex = speedIndex;
    }
}