// 0_Core/Utilities/Extensions.cs
using UnityEngine;

public static class Extensions
{
    // ����������� DateTime � ������� �����
    public static string ToGameDateFormat(this System.DateTime date)
    {
        return $"{date.Day:00}.{date.Month:00}.{date.Year}";
    }

    // ���������� �� ���� (��� UI)
    public static float RoundToNearest(this float value, float step)
    {
        return Mathf.Round(value / step) * step;
    }
}