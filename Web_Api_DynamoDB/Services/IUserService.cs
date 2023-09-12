namespace Web_Api_DynamoDB.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllusers();
        Task<User> Createuser(User user);

    }
}
