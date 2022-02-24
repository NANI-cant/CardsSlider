using System;
using UnityEngine;

public static class PlayerPrefsExtensions {
    public static void SetBool(this PlayerPrefs prefs, string key, bool value) {
        PlayerPrefs.SetInt(key, Convert.ToInt32(value));
    }

    public static bool GetBool(this PlayerPrefs prefs, string key, bool defaultValue) {
        return Convert.ToBoolean(PlayerPrefs.GetInt(key, Convert.ToInt32(defaultValue)));
    }
}
