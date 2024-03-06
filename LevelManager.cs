namespace ApusGame
{
    using UnityEngine;
    using UnityEngine.AddressableAssets;
    using UnityEngine.ResourceManagement.AsyncOperations;
    using UnityEngine.ResourceManagement.ResourceProviders;
    using UnityEngine.SceneManagement;
    using System.Collections;
    
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private byte levelIndex;

        public byte LevelIndex => levelIndex;
        
        public void SetLevelIndex(byte _levelIndex)
        {
            levelIndex = _levelIndex;
        }
        
        public void LoadScene(string sceneName, LoadSceneMode loadSceneMode = LoadSceneMode.Single, System.Action callback = null)
        {
            StartCoroutine(LoadSceneAsync(sceneName, loadSceneMode, callback));
        }

        IEnumerator LoadSceneAsync(string sceneName, LoadSceneMode loadSceneMode = LoadSceneMode.Single, System.Action callback = null)
        {
            AsyncOperationHandle<SceneInstance> loadHandle = Addressables.LoadSceneAsync(
                sceneName, loadSceneMode
            );

            yield return loadHandle;

            if (loadHandle.Status == AsyncOperationStatus.Succeeded)
            {
                callback?.Invoke();
            }
        }

        public void LoadLevelObject(string assetKey, System.Action<GameObject> callback = null)
        {
            StartCoroutine(LoadLevelAsync(assetKey, callback));
        }

        IEnumerator LoadLevelAsync(string assetKey, System.Action<GameObject> callback = null)
        {
            AsyncOperationHandle<GameObject> opHandle = Addressables.LoadAssetAsync<GameObject>(assetKey);
            yield return opHandle;

            if (opHandle.Status == AsyncOperationStatus.Succeeded)
            {
                GameObject objRef = opHandle.Result;
                GameObject objSpawned = Instantiate(objRef);

                callback?.Invoke(objSpawned);
            }
        }
    }
}
