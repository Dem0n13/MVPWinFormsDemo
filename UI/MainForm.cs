using System;
using System.Windows.Forms;
using Dem0n13.MVP.Presentation.Views;

namespace Dem0n13.MVP.UI
{
    public partial class MainForm : Form, IMainView
    {
        private readonly ApplicationContext _context;
        public MainForm(ApplicationContext context)
        {
            _context = context;
            InitializeComponent();

            btnChangeUsername.Click += (sender, args) => Invoke(ChangeUsername);
        }

        public new void Show()
        {
            _context.MainForm = this;
            base.Show();
        }

        public void SetUserInfo(string username, string password)
        {
            lblUsername.Text = username;
            lblPassword.Text = password;
        }

        public event Action ChangeUsername;

        private void Invoke(Action action)
        {
            if (action != null) action();
        }
    }
}
