namespace VeryDisco.Common
{
#if USING_NAUGHTY_ATTRIBUTES
    using NaughtyAttributes;
#endif
    using UnityEngine;

    [System.Serializable]
    public class PresentData
    {
        public int id;
        public string name;
#if USING_NAUGHTY_ATTRIBUTES
        [ShowAssetPreview] 
#endif
        public Sprite avatar;
    }
}
