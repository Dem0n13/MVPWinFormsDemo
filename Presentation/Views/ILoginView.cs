using System;
using Dem0n13.MVP.Presentation.Common;

namespace Dem0n13.MVP.Presentation.Views
{
    public interface ILoginView : IView
    {
        string Username { get; }
        string Password { get; }
        event Action Login;
        void ShowError(string errorMessage);
    }
}