using UnityEngine;

namespace FPSAmuk
{
    public sealed class UiInterface
    {
        private FlashLightUiText _flashLightUiText;

        public FlashLightUiText LightUiText
        {
            get
            {
                if (!_flashLightUiText)
                    _flashLightUiText = Object.FindObjectOfType<FlashLightUiText>();
                return _flashLightUiText;
            }
        }
    }
}