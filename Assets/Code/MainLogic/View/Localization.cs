using System.Collections;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

namespace Code.MainLogic.View
{
    public class Localization:MonoBehaviour
    {
        [SerializeField]
        private Button _englishButton;
  
        [SerializeField]
        private Button _russianButton;

        [SerializeField] private Text _start;
        [SerializeField] private Text _fight;
        [SerializeField] private Text _reward;

        private void Start(){
            ChangedLocaleEvent(null);
            LocalizationSettings.SelectedLocaleChanged += ChangedLocaleEvent;
      
            _russianButton.onClick.AddListener(() => ChangeLanguage(1));
            _englishButton.onClick.AddListener(() => ChangeLanguage(0));
        }

        private void OnDestroy()
        {
            _russianButton.onClick.RemoveAllListeners();
            _englishButton.onClick.RemoveAllListeners();
        }

        private void ChangedLocaleEvent(Locale locale)
        {
            StartCoroutine(OnChangedLocale(locale));
        }

        private IEnumerator OnChangedLocale(Locale locale)
        {
            var loadingOperation = LocalizationSettings.StringDatabase.GetTableAsync("New Table");
            yield return loadingOperation;
       
            if (loadingOperation.Status == AsyncOperationStatus.Succeeded)
            {
                var table = loadingOperation.Result;
                _start.text = table.GetEntry("StartGame")?.GetLocalizedString();
                _fight.text = table.GetEntry("Fight")?.GetLocalizedString();
                _reward.text = table.GetEntry("Reward")?.GetLocalizedString();
                
            }
            else
            {
                Debug.Log("Could not load String Table\n" + loadingOperation.OperationException);
            }
        }

        private void ChangeLanguage(int index)
        {
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
        }
    }
}