using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Localization.Settings;

public class LanguageSelector : MonoBehaviour
{
    public UnityEvent OnLanguageSelected;
    public bool dontDestroy;

    public void ChangeLocale(int localeID)
    {
        StartCoroutine(this.SetLocale(localeID));
    }

    private IEnumerator SetLocale(int localeID)
    {
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeID];
        PlayerPrefs.SetInt(PlayerPrefKeys.LOCATION_KEY, localeID);
        this.OnLanguageSelected?.Invoke();
    }
}
