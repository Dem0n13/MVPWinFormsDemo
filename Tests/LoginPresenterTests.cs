using System;
using Dem0n13.MVP.DomainModel;
using Dem0n13.MVP.Presentation.Common;
using Dem0n13.MVP.Presentation.Presenters;
using Dem0n13.MVP.Presentation.Views;
using NSubstitute;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class LoginPresenterTests
    {
        private IApplicationController _controller;
        private ILoginView _view;
        
        [SetUp]
        public void SetUp()
        {
            _controller = Substitute.For<IApplicationController>();
            _view = Substitute.For<ILoginView>();
            var service = Substitute.For<ILoginService>();
            service.Login(Arg.Any<User>())
                .Returns(info => info.Arg<User>().Name == "admin" && info.Arg<User>().Password == "password");
            var presenter = new LoginPresenter(_controller, _view, service);
            presenter.Run();
        }
        
        [Test]
        public void InvalidUser()
        {
            _view.Username.Returns("Vladimir");
            _view.Password.Returns("VladimirPass");
            _view.Login += Raise.Event<Action>();
            _view.Received().ShowError(Arg.Any<string>());
            _controller.DidNotReceive().Run<MainPresener, User>(Arg.Any<User>());
        }

        [Test]
        public void ValidUser()
        {
            _view.Username.Returns("admin");
            _view.Password.Returns("password");
            _view.Login += Raise.Event<Action>();
            _view.DidNotReceive().ShowError(Arg.Any<string>());
            _controller.Received().Run<MainPresener, User>(Arg.Is<User>(user => user.Name == "admin" && user.Password == "password"));
        }
    }
}