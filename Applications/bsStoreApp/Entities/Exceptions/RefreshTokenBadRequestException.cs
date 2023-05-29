namespace Entities.Exceptions
{
    public class RefreshTokenBadRequestException : BadRequestException
    {
        public RefreshTokenBadRequestException() : base($"Invalid client request. The tokenDto has some invalid values.")
        {
        }
    }
}
