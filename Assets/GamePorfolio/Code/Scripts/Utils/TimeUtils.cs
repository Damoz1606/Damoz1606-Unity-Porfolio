using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeUtils : MonoBehaviour
{
    public static string SecondToMinutes(int time)
    {
        int minutes = time / 60;
        int seconds = time % 60;

        string minutesString = minutes < 10 ? $"0{minutes}" : $"{minutes}";
        string secondsString = seconds < 10 ? $"0{seconds}" : $"{seconds}";

        return $"{minutesString}:{secondsString}";
    }
}
