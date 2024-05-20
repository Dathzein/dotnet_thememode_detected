using prototype_mode_dark_light.contracts;

namespace prototype_mode_dark_light
{
    public partial class Form1 : Form
    {

        private readonly IThemeService _themeService;

        public Form1(IThemeService themeService)
        {
            _themeService = themeService;
            InitializeComponent();
            ApplyTheme();
            _themeService.ThemeChanged += OnThemeChanged;
        }

        protected override void OnLoad(EventArgs e) 
        {
            base.OnLoad(e);
            ApplyTheme();
            ShowThemeMessage();
        }

        private void ShowThemeMessage()
        {
            string theme = _themeService.IsDarkMode ? "Oscuro" : "Claro";
            MessageBox.Show($"El tema actual del sistema es: {theme}");
        }

        private  void ApplyTheme()
        {
            if(_themeService.IsDarkMode)
            {
                this.BackColor = System.Drawing.Color.FromArgb(30,30,30);
                this.ForeColor = System.Drawing.Color.White;
                foreach (Control control in this.Controls)
                {
                    ApplyDarkTheme(control);
                }
            }
            else
            {
                this.BackColor = System.Drawing.Color.White;
                this.ForeColor = System.Drawing.Color.Black;
                foreach (Control control in this.Controls)
                {
                    ApplyLightTheme(control);
                }
            }
        }

        private void ApplyDarkTheme(Control control)
        {
            this.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.ForeColor = System.Drawing.Color.White;
            foreach (Control childControl in control.Controls)
            {
                ApplyDarkTheme(childControl);
            }
        }

        private void ApplyLightTheme(Control control)
        {
            this.BackColor = System.Drawing.Color.White;
            this.ForeColor = System.Drawing.Color.Black;
            foreach (Control childControl in control.Controls)
            {
                ApplyLightTheme(childControl);
            }
        }

        private void OnThemeChanged(object sender, EventArgs e)
        {
            ApplyTheme();
        }
        private void ToggleThemeButton_Click(object sender, EventArgs e)
        {
            _themeService.ToggleTheme();
        }
        private void OnFormClosed(FormClosedEventArgs e)
        {
            _themeService.ThemeChanged -= OnThemeChanged;
            base.OnFormClosed(e);
        }
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code


        private Button toggleThemeButton;
        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toggleThemeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.toggleThemeButton.Location = new Point(13, 13);
            this.toggleThemeButton.Name = "toggleThemeButton";
            this.toggleThemeButton.Size = new Size(75, 23);
            this.toggleThemeButton.TabIndex = 0;
            this.toggleThemeButton.Text = "Toggle Theme";
            this.toggleThemeButton.UseVisualStyleBackColor = true;
            this.toggleThemeButton.Click += new EventHandler(this.ToggleThemeButton_Click);

            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);

            this.Controls.Add(this.toggleThemeButton); 

            this.Text = "Form1";
            this.ResumeLayout(false);
        }

        #endregion
    }
}
