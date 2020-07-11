using System.Runtime.InteropServices;
using UnityEngine;

namespace FPSAmuk
{
    public sealed class FlashLightController : BaseControllers, IExecute, IInitialization
    {
        private FlashLightModel _flashLightModel;

        public void Initialization()
        {
            UiInterface.LightUiText.SetActive(false);
        }

        public override void On(params BaseObjectScene[] flashLight)
        {
            if (IsActive) return;
            if (flashLight.Length > 0) _flashLightModel = flashLight[0] as FlashLightModel;
            if (_flashLightModel == null) return;
            if (_flashLightModel.BatteryChargeCurrent <= 1.0) return;
            base.On(_flashLightModel);
            _flashLightModel.Switch(FlashLightActiveType.On);
            UiInterface.LightUiText.SetActive(true);
        }

        public override void Off()
        {
            if (!IsActive) return;
            base.Off();
            _flashLightModel.Switch(FlashLightActiveType.Off);
            
            UiInterface.LightUiText.SetActive(false);
        }

        public void Execute()
        {
            if (!IsActive)
            {
                //if (_flashLightModel.BatteryRecharge()) return;

                return;
            }
            if (_flashLightModel.EditBatteryCharge())
            {
                UiInterface.LightUiText.Text = _flashLightModel.BatteryChargeCurrent;
                _flashLightModel.Rotation();
            }
            else
            {
                Off();
                //if (_flashLightModel.BatteryRecharge()) return;
            }
        }
    }
}
