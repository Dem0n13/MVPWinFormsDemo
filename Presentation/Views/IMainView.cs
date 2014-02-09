using System;
using Dem0n13.MVP.Presentation.Common;

namespace Dem0n13.MVP.Presentation.Views
{
    public interface IMainView : IView
    {
        void SetUserInfo(string username, string password);
        event Action ChangeUsername;
    }
}