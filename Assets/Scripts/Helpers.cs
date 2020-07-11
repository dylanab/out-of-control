using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helpers
{
    public static void Shuffle<T>(List<T> l) {
        for (int t = 0; t < l.Count; t++ )
        {
            T tmp = l[t];
            int r = Random.Range(t, l.Count);
            l[t] = l[r];
            l[r] = tmp;
        }
    }
}
