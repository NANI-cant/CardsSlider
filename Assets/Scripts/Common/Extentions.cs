using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class Extentions {
    static public float PixelsToUnits(float pixels, Camera camera) {
        float ortho = camera.orthographicSize;
        float pixelH = camera.pixelHeight;
        return (pixels * ortho * 2) / pixelH;
    }
}
