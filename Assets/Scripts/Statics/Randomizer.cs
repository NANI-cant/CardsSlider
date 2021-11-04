using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Randomizer {
    public static bool RandomChance(float chance) {
        if (chance <= 0) { return false; }
        if (chance >= 1) { return true; }

        if (Random.Range(0f, 1f) < chance) {
            return true;
        }
        else {
            return false;
        }
    }

    public static T TakeRandomFromList<T>(List<T> list) {
        int randIndex = Random.Range(0, list.Count);
        return list[randIndex];
    }

    public static T TakeRandomFromList<T>(List<T> list, T notThis) {
        int randIndex = Random.Range(0, list.Count);
        T item = list[randIndex];
        while (item.Equals(notThis)) {
            randIndex = Random.Range(0, list.Count);
            item = list[randIndex];
        }

        return item;
    }
}
