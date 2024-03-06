namespace VeryDisco
{
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.SceneManagement;
    using TMPro;

    public class LoadingScreen : MonoBehaviour
    {
        private AsyncOperation loadOperation;

        [SerializeField] private Image progressBar;
        [SerializeField] private TextMeshProUGUI percentText;
        [SerializeField] private Text msgText;
        [SerializeField] private bool loadNextScene;

        private float currentValue;
        private float targetValue;

        [SerializeField]
        [Range(0, 1)]
        private float progressAnimationMultiplier = 0.15f;
        public bool isLoading { get; private set; }

        private void Start()
        {
            if (loadNextScene)
            {
                LoadingNextScene();
            }
        }

        public void SetTextMsg(string msg)
        {
            msgText.text = msg;
        }

        public void LoadingNextScene()
        {
            if (progressBar) progressBar.fillAmount = currentValue = targetValue = 0;

            var currentScene = SceneManager.GetActiveScene();
            loadOperation = SceneManager.LoadSceneAsync(currentScene.buildIndex + 1);

            isLoading = true;
        }

        public void LoadingScene(byte index)
        {
            if (progressBar) progressBar.fillAmount = currentValue = targetValue = 0;

            var currentScene = SceneManager.GetActiveScene();
            loadOperation = SceneManager.LoadSceneAsync(index);

            loadOperation.allowSceneActivation = false;
            isLoading = true;
        }

        public void AllowSceneActivatation()
        {
            loadOperation.allowSceneActivation = true;
        }

        void Update()
        {
            if (!isLoading) return;

            targetValue = loadOperation.progress / 0.9f;
            currentValue = Mathf.MoveTowards(currentValue, targetValue, progressAnimationMultiplier * Time.deltaTime);

            if (progressBar)
            {
                progressBar.fillAmount = currentValue;

                if (percentText)
                {
                    float InPercent = currentValue * 100;
                    percentText.text = string.Format("{0}%", InPercent.ToString("F0"));
                }
            }

            if (Mathf.Approximately(currentValue, 1))
            {
                isLoading = false;
            }
        }
    }
}
