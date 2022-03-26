namespace EntityFrameworkExample.Authentication;

public interface ICurrentUserService
{
    IUserSession GetCurrentUser();
}
