using UnityEngine;

namespace FPSAmuk
{
    public sealed class InputController : BaseControllers, IExecute
    {
        private KeyCode _activeFlashLight = KeyCode.F;
        private KeyCode _cancel = KeyCode.Escape;
        private KeyCode _reloadClip = KeyCode.R;
        private int _mouseButton = (int)MouseButton.LeftButton;
        private FlashLightModel _flashLightModel;

        public InputController()
        {
            Cursor.lockState = CursorLockMode.Locked;
            _flashLightModel = Object.FindObjectOfType<FlashLightModel>();
        }

        public void Execute()
        {
            if (!IsActive) return;
            if (Input.GetKeyDown(_activeFlashLight))
            {
                ServiceLocator.Resolve<FlashLightController>().Switch(_flashLightModel);
            }
        }
    }
}
