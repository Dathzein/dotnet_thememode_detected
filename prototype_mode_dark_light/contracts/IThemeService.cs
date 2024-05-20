using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prototype_mode_dark_light.contracts
{
    public interface IThemeService
    {

        bool IsDarkMode { get; }
        void ToggleTheme();
        event EventHandler ThemeChanged;

    }
}
