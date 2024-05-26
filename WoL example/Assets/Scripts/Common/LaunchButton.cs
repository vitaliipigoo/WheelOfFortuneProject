using UnityEngine;
using UnityEngine.UI;
using Wheel_of_Luck.Services;
using Zenject;

namespace Common
{
    public class LaunchButton : MonoBehaviour
    {
        private Transform _canvas;
        private Button _launchButton;
        
        private IWheelOfLuckService _wheelOfLuckService;
        
        [Inject]
        public void Construct(IWheelOfLuckService wheelOfLuckService)
        {
            _canvas = FindObjectOfType<Canvas>().transform;
            _launchButton = gameObject.GetComponent<Button>();
            _wheelOfLuckService = wheelOfLuckService;
            
            AddButtonsListeners();
        }
        
        private void OnDestroy()
        {
            _launchButton.onClick.RemoveAllListeners();
        }
        
        private void AddButtonsListeners()
        {
            _launchButton.onClick.AddListener(OnLaunchClick);
        }

        private void OnLaunchClick()
        {
            _wheelOfLuckService.OpenWheelOfLuck(_canvas);
        }
    }
}