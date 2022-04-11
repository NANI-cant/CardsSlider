using System;

public static class ObjectExtensions {
    public static object Do(this object obj, Action action, bool when) {
        if (when) {
            action?.Invoke();
        }
        return obj;
    }
}