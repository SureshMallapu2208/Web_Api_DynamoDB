using Amazon.DynamoDBv2.DataModel;
using API.SQS;
using API.SNS;
using System.Text.Json;

namespace Web_Api_DynamoDB.Services
{
    public class UserService : IUserService
    {
        private readonly IDynamoDBContext _dbContext;

        private readonly IQueueService _queueService;

        private readonly INotificationService _notificationService;
        public UserService(IDynamoDBContext context, IQueueService queueService, INotificationService notificationService)
        {
            _dbContext = context;
            _queueService = queueService;
            _notificationService = notificationService;
        }
        public async Task<User> Createuser(User user)
        {
            var userData = await _dbContext.LoadAsync<User>(user.Id);
            if (userData != null) return null;
            await _dbContext.SaveAsync(user);
            await _queueService.PushQueueItem(JsonSerializer.Serialize(user));
            await _notificationService.Send(new Message(string.Empty, "+917207700003", "Sample Message From Console", MessageType.Transactional));
            return user;
        }

        public async Task<List<User>> GetAllusers()
        {
            return await _dbContext.ScanAsync<User>(default).GetRemainingAsync();
        }
    }
}
