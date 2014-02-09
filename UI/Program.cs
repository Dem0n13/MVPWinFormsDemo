using System.Windows.Forms;
using Dem0n13.MVP.DomainModel;
using Dem0n13.MVP.Presentation.Common;
using Dem0n13.MVP.Presentation.Presenters;
using Dem0n13.MVP.Presentation.Views;

namespace Dem0n13.MVP.UI
{
    internal static class Program
    {
        public static readonly ApplicationContext Context = new ApplicationContext();

        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var controller = new ApplicationController(new LightInjectAdapder())
                .RegisterView<ILoginView, LoginForm>()
                .RegisterView<IMainView, MainForm>()
                .RegisterView<IChangeUsernameView, ChangeUsernameForm>()
                .RegisterService<ILoginService, StupidLoginService>()
                .RegisterInstance(new ApplicationContext());

            controller.Run<LoginPresenter>();
        }
    }
}
