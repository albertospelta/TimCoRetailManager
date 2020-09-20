using System;

namespace TRMDesktopUI.Library.Models
{
    public interface ILoggedInUserModel
    {
        DateTime CreateData { get; set; }
        string EmailAddress { get; set; }
        string FirstName { get; set; }
        string Id { get; set; }
        string LastName { get; set; }
        string Token { get; set; }
    }
}