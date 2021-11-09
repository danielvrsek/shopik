namespace Shopik.Shared.Account.Common
{
    public class IdentityValidationException : Exception
    {
        public IdentityValidationException(string message, params IdentityValidationError[] identityErrors) : base(message)
        {
            Errors = identityErrors;
        }

        public IdentityValidationError[] Errors { get; }
    }
}
