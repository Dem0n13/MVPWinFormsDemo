using System;
using Dem0n13.MVP.Presentation.Common;

namespace Dem0n13.MVP.Presentation.Views
{
    public interface IChangeUsernameView : IView
    {
        string Username { get; }

        event Action Save;
    }
}