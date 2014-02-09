using System;
using System.Windows.Forms;
using Dem0n13.MVP.Presentation.Views;

namespace Dem0n13.MVP.UI
{
    public partial class ChangeUsernameForm : Form, IChangeUsernameView
    {
        public ChangeUsernameForm()
        {
            InitializeComponent();

            btnSave.Click += (sender, args) => Invoke(Save);
        }

        public new void Show()
        {
            ShowDialog();
        }

        public string Username { get { return txtUsername.Text; } }
        public event Action Save;

        private void Invoke(Action action)
        {
            if (action != null) action();
        }
    }
}
