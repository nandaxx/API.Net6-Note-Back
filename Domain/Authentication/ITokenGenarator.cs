using Domain.Entities;

namespace Domain.Authentication
{
    public interface ITokenGenarator
    {
        dynamic Generator(Person person);
    }
}
