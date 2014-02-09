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
    public class MainPresenterTests
    {
        private IApplicationController _controller;
        private MainPresener _presenter;
        private IMainView _view;
        private User _user;

        [SetUp]
        public void SetUp()
        {
            _controller = Substitute.For<IApplicationController>();
            _user = new User { Name = "admin", Password = "password" };
            _view = Substitute.For<IMainView>();
            _presenter = new MainPresener(_controller, _view);
            _presenter.Run(_user);
        }
        
        [Test]
        public void ViewInit()
        {
            _view.Received().SetUserInfo("admin", "********");
        }
        
        [Test]
        public void ChangeUsername()
        {
            _view.ChangeUsername += Raise.Event<Action>();
            _controller.Received().Run<ChangeUsernamePresenter, User>(_user);
        }
    }
}