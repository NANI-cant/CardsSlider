using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Numbers {
    public static KeyValuePair<int, int> GetNearestMultipliers(int number) {
        if (number <= 0) {
            return new KeyValuePair<int, int>(0, 0);
        }

        int targetMultiplier1 = 1;
        int targetMultiplier2 = number;
        int minDif = targetMultiplier2 - targetMultiplier1;

        for (int multiplier1 = 2; multiplier1 <= number / 2; multiplier1++) {
            if (number % multiplier1 == 0) {
                int multiplier2 = number / multiplier1;
                if (multiplier2 - multiplier1 < minDif) {
                    minDif = multiplier2 - multiplier1;
                    targetMultiplier1 = multiplier1;
                    targetMultiplier2 = multiplier2;
                }
            }
        }

        return new KeyValuePair<int, int>(targetMultiplier1, targetMultiplier2);
    }
}
