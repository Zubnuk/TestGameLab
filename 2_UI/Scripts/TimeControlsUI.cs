using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeControlsUI : MonoBehaviour
{
    [Header("������")]
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _speedUpButton;

    [Header("������")]
    [SerializeField] private TMP_Text _speedText;

    private void Start()
    {
        // �������� �� ������
        _pauseButton.onClick.AddListener(TogglePause);
        _speedUpButton.onClick.AddListener(SetNextSpeed);

        // ������������� ������
        UpdateSpeedText();
    }

    private void TogglePause()
    {
        GameManager.Instance.TogglePause();
        UpdateSpeedText();
    }

    private void SetNextSpeed()
    {
        GameManager.Instance.SetNextSpeed();
        UpdateSpeedText();
    }

    private void UpdateSpeedText()
    {
        string speed = GameManager.Instance.CurrentSpeed switch
        {
            0 => "�����",
            1 => "1x",
            2 => "2x",
            3 => "3x",
            _ => "?"
        };

        _speedText.text = speed;
    }
}