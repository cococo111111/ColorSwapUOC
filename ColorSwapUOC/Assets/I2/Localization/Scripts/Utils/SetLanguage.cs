using EasyMobile;
using UnityEngine;
namespace I2.Loc
{
	[AddComponentMenu("I2/Localization/SetLanguage Button")]
	public class SetLanguage : MonoBehaviour 
	{
		public string _Language;

#if UNITY_EDITOR
		public LanguageSource mSource;
#endif
		
		void OnClick()
		{
            ApplyLanguage();
        }

		public void ApplyLanguage()
		{
            GameServices.UnlockAchievement(EM_GameServicesConstants.Achievement_MULTILINGUAL);
            Debug.Log("AQUI");
            if ( LocalizationManager.HasLanguage(_Language))
			{
				LocalizationManager.CurrentLanguage = _Language;
			}
		}
    }
}