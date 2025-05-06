using UnityEngine;
using System;

public class TimeManager : MonoBehaviour
{
    public event Action OnDayPassed;
    public event Action OnMonthPassed;
    public event Action OnYearPassed;

    private int _currentDay = 1;
    private int _currentMonth = 1;
    private int _currentYear = 1200;
    private float _timeAccumulator = 0f;

    // ������ ���� � ������� (������ - 0, ������� - 11)
    private int[] _daysInMonth => new int[] {
        31, IsLeapYear(_currentYear) ? 29 : 28, 31, 30, 31, 30,
        31, 31, 30, 31, 30, 31
    };

    private void Update()
    {
        if (GameManager.Instance.CurrentSpeed <= Mathf.Epsilon) return;

        _timeAccumulator += Time.deltaTime * GameManager.Instance.CurrentSpeed;

        // ������������ ��� ����������� ��� �� ����
        while (_timeAccumulator >= 1f)
        {
            _timeAccumulator -= 1f;
            IncrementDay();
        }
    }

    private void IncrementDay()
    {
        _currentDay++;
        Debug.Log($"���� ��������: {_currentDay} | ������� �����: {_currentMonth}");

        // �������� ���������� ���������� ���� ��� �������� ������
        int daysInCurrentMonth = _daysInMonth[_currentMonth - 1];
        Debug.Log($"���� � ������� ������: {daysInCurrentMonth}");

        if (_currentDay > daysInCurrentMonth)
        {
            Debug.Log("����� ��������! ���������� ����...");
            _currentDay = 1;
            IncrementMonth();
        }

        OnDayPassed?.Invoke();
    }

    private void IncrementMonth()
    {
        _currentMonth++;
        Debug.Log($"����� �����: {_currentMonth}");

        OnMonthPassed?.Invoke();
        GameManager.Instance.ProvinceManager.UpdateProvinces();
        GameManager.Instance.ResourceManager.UpdateResources();

        if (_currentMonth > 12)
        {
            _currentMonth = 1;
            IncrementYear();
        }
    }

    private void IncrementYear()
    {
        _currentYear++;
        Debug.Log($"����� ���: {_currentYear}");
        OnYearPassed?.Invoke();
    }

    // �������� ����������� ���� (��������� ���������)
    private bool IsLeapYear(int year) => year % 4 == 0;

    public string GetFormattedDate() => $"{_currentDay:00}.{_currentMonth:00}.{_currentYear}";
    public TimeSaveData GetSaveData() => new TimeSaveData(_currentDay, _currentMonth, _currentYear);

    public void LoadData(TimeSaveData data)
    {
        _currentDay = Mathf.Clamp(data.Day, 1, 31);
        _currentMonth = Mathf.Clamp(data.Month, 1, 12);
        _currentYear = data.Year;
    }
}

[System.Serializable]
public class TimeSaveData
{
    public int Day;
    public int Month;
    public int Year;

    public TimeSaveData(int day, int month, int year)
    {
        Day = day;
        Month = month;
        Year = year;
    }
}