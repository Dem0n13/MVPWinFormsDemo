using Dem0n13.MVP.DomainModel;
using Dem0n13.MVP.Presentation.Common;
using Dem0n13.MVP.Presentation.Views;

namespace Dem0n13.MVP.Presentation.Presenters
{
    public class MainPresener : BasePresener<IMainView, User>
    {
        private User _user;
        
        public MainPresener(IApplicationController controller, IMainView view) : base(controller, view)
        {
            View.ChangeUsername += ChangeUsername;
        }

        public override void Run(User argument)
        {
            _user = argument;
            UpdateUserInfo();
            View.Show();
        }

        private void ChangeUsername()
        {
            Controller.Run<ChangeUsernamePresenter, User>(_user);
            UpdateUserInfo();
        }

        private void UpdateUserInfo()
        {
            View.SetUserInfo(_user.Name, new string('*', _user.Password.Length));
        }
    }
}