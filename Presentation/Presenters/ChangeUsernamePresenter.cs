using System;
using Dem0n13.MVP.DomainModel;
using Dem0n13.MVP.Presentation.Common;
using Dem0n13.MVP.Presentation.Views;

namespace Dem0n13.MVP.Presentation.Presenters
{
    public class ChangeUsernamePresenter : BasePresener<IChangeUsernameView, User>
    {
        private User _user;
        
        public ChangeUsernamePresenter(IApplicationController controller, IChangeUsernameView view) : base(controller, view)
        {
            View.Save += () => ChangeUsername(View.Username);
        }

        private void ChangeUsername(string username)
        {
            if (username == null)
                throw new ArgumentNullException("username");
            if (username != string.Empty)
            {
                _user.Name = username;
                View.Close();
            }
        }

        public override void Run(User argument)
        {
            _user = argument;
            View.Show();
        }
    }
}