
namespace VeryDisco.UI.Common
{
    using UnityEngine;
    using UnityEngine.UI;

    public class SimpleItemViewUI : MonoBehaviour
    {
        [SerializeField] private Image avatarImg;

        public void ShowItemContent(Sprite iconSprite)
        {
            avatarImg.sprite = iconSprite;
        }
    }
}
