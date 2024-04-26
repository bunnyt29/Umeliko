namespace Umeliko.Infrastructure.Identity;

using System.Collections.Generic;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user, IList<string> roles);
}
