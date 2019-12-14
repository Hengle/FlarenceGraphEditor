using UnityEngine;

namespace FLLib {
    public static class ColorHelper {

        public static Color GetRandomColor(float a) {
            var r = Random.Range(0, 1f);
            var g = Random.Range(0, 1f);
            var b = Random.Range(0, 1f);
            return new Color(r,g,b,a);
        }

        public static Color Blend(Color Color1, Color Color2) {

            var NewColor = new Color {
                r = 255 - Mathf.Sqrt((Mathf.Pow(255 - Color1.r, 2) + Mathf.Pow(255 - Color2.r, 2)) / 2),
                g = 255 - Mathf.Sqrt((Mathf.Pow(255 - Color1.g, 2) + Mathf.Pow(255 - Color2.g, 2)) / 2),
                b = 255 - Mathf.Sqrt((Mathf.Pow(255 - Color1.b, 2) + Mathf.Pow(255 - Color2.b, 2)) / 2),
                a = Color1.a > Color2.a ? Color1.a : Color2.a
            };

            return NewColor;
        }

        public static Color From255To1(int r, int g,int b,int a=255) {
            return new Color(r/255f,g/255f,b/255f,a/255f);
        }

    }
}