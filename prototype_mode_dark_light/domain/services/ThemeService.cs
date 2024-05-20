using prototype_mode_dark_light.contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace prototype_mode_dark_light.domain.services
{
    public class ThemeService : IThemeService
    {
		public const string RegistryKeyPath = @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";
		public const string RegistryValueName = "AppsUseLightTheme";

        public bool IsDarkMode { get; private set; }

        public event EventHandler ThemeChanged;

        public ThemeService()
        {
			IsDarkMode = GetSystemTheme();
			SystemEvents.UserPreferenceChanged += OnUserPreferenceChanged;
        }

        public bool GetSystemTheme()
        {
			try
			{
				using( var key = Registry.CurrentUser.OpenSubKey(RegistryKeyPath))
	 			{
					var registryValueObject = key?.GetValue(RegistryValueName);
					if (registryValueObject == null)
					{
						return false;
					}

					var registryValue = (int)registryValueObject!;

					return registryValue == 0;
				}
			}
			catch
			{

				return false;
			}
        }

        public void ToggleTheme()
        {
            IsDarkMode = !IsDarkMode;
			OnThemeChanged();
        }

        public void UpdateTheme()
        {
            IsDarkMode = GetSystemTheme();
            OnThemeChanged();
        }

        private void OnUserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
		{
			if(e.Category == UserPreferenceCategory.General)
			{
                UpdateTheme();
			}
		}

        protected virtual void OnThemeChanged()
		{
			ThemeChanged?.Invoke(this, EventArgs.Empty);
		}

		~ThemeService()
		{
			SystemEvents.UserPreferenceChanged -= OnUserPreferenceChanged;
		}
    }
}
