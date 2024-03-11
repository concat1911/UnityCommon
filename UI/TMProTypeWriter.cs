namespace VeryDisco.CommonUI
{
    using Cysharp.Threading.Tasks;
    using System.Threading;
    using TMPro;
    using UnityEngine;

    public class TMProTypeWriter : MonoBehaviour
    {
        [SerializeField] float typingSpeed = 0.1f;
        [SerializeField] private string originalText;
        [SerializeField] private TextMeshProUGUI textMeshPro;
        public bool IsPlayingEffect { get; private set; }
        private CancellationTokenSource cancellationTokenSource;

        public System.Action OnEffectFinish = delegate { };

        private void Start()
        {
            IsPlayingEffect = false;
            cancellationTokenSource = new CancellationTokenSource();
        }

        public void SetTypeSpeed(float speed)
        {
            if (IsPlayingEffect) return;
            typingSpeed = speed;
        }

        public void SetText(string text)
        {
            if (IsPlayingEffect) return;
            originalText = text;
        }

        public async void PlayEffect()
        {
            if (IsPlayingEffect) return;
            CancellationToken cancellationToken = cancellationTokenSource.Token;
            await TypeWriterTextJob(cancellationToken);
        }

        protected virtual async UniTask TypeWriterTextJob(CancellationToken cancellationToken)
        {
            IsPlayingEffect = true;

            textMeshPro.text = string.Empty;

            for (int i = 0; i < originalText.Length; i++)
            {
                // Player Sound Effect here
                cancellationToken.ThrowIfCancellationRequested();
                textMeshPro.text += originalText[i];
                await UniTask.WaitForSeconds(typingSpeed);
            }
            
            IsPlayingEffect = false;
            OnEffectFinish.Invoke();
        }
    }
}
