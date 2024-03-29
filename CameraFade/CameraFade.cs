namespace ApusGame
{
    using UnityEngine;
    using UnityEngine.UI;
    using DG.Tweening;
    using VeryDisco;

    /// <summary>
    /// using for Camera Fade Effect
    /// </summary>
    public class CameraFade : GenericSingleton<CameraFade>
    {
        [Header("Properties")]
        [SerializeField] Image fadeImage;
        [SerializeField] float duration = 0.5f;
        [SerializeField] Color fadeColor = Color.black;

        private Color noAlphaColor = new Color(1, 1, 1, 0);

        public static void FadeIn(System.Action callback = null)
        {
            instance.fadeImage.DOColor(instance.fadeColor, instance.duration).OnComplete(() => callback?.Invoke());
        }

        public static void FadeIn(Color fadeCol, System.Action callback = null)
        {
            instance.fadeImage.DOColor(fadeCol, instance.duration).OnComplete(() => callback?.Invoke());
        }

        public static void FadeIn(float duration, System.Action callback = null)
        {
            instance.fadeImage.DOColor(instance.fadeColor, duration).OnComplete(() => callback?.Invoke());
        }

        public static void FadeIn(Color color, float duration, System.Action callback = null)
        {
            instance.fadeImage.DOColor(color, duration).OnComplete(() => callback?.Invoke());
        }

        public static void FadeOut(System.Action callback = null)
        {
            instance.fadeImage.color = instance.fadeColor;
            instance.fadeImage.DOColor(instance.noAlphaColor, instance.duration).OnComplete(() => callback?.Invoke());
        }

        public static void FadeOut(Color fadeCol, System.Action callback = null)
        {
            instance.fadeImage.color = fadeCol;
            instance.fadeImage.DOColor(instance.noAlphaColor, instance.duration).OnComplete(() => callback?.Invoke());
        }

        public static void FadeOut(float duration, System.Action callback = null)
        {
            instance.fadeImage.color = instance.fadeColor;
            instance.fadeImage.DOColor(instance.noAlphaColor, duration).OnComplete(() => callback?.Invoke());
        }

        public static void FadeOut(Color color, float duration, System.Action callback = null)
        {
            instance.fadeImage.color = color;
            instance.fadeImage.DOColor(instance.noAlphaColor, duration).OnComplete(() => callback?.Invoke());
        }

        public static void FadeInOut(Color color, float durationIn, float durationOut, System.Action callback = null)
        {
            instance.fadeImage.DOColor(color, durationIn)
                .OnComplete(() =>
                {
                    instance.fadeImage.DOColor(instance.noAlphaColor, durationOut)
                    .OnComplete(() => callback?.Invoke());
                });
        }
    }
}
