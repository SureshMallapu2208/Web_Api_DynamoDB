using Amazon.Runtime;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;

namespace API.SNS
{
    public class NotificationService : INotificationService
    {
        private readonly IAmazonSimpleNotificationService _snsService;
        private readonly string TopicArn;

        public NotificationService(IAmazonSimpleNotificationService snsService)
        {
            _snsService = snsService;
            TopicArn = string.Empty;
        }
        public async Task RegisterSubscirption(string topic, string email)
        {
            try
            {
                await _snsService.SubscribeAsync(topic, "email", email);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task RegisterSubscirption(string email)
        {
            try
            {
                await _snsService.SubscribeAsync(TopicArn, "email", email);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Send(Message message)
        {

            var attributes = new Dictionary<string, MessageAttributeValue>();
            //attributes.Add("AWS.SNS.SMS.SenderID", new MessageAttributeValue() { StringValue = message.SenderId, DataType = "String" });
            attributes.Add("AWS.SNS.SMS.SMSType", new MessageAttributeValue() { StringValue = "Transactional", DataType = "String" }); ;

            var request = new Amazon.SimpleNotificationService.Model.PublishRequest();
            request.PhoneNumber = $"{message.PhoneNumber}";
            request.Message = message.TextMessage;
            request.MessageAttributes = attributes;

            await _snsService.PublishAsync(request);
        }

        public async Task SendUploadNotification(string topic, string message)
        {
            try
            {
                var request = new PublishRequest
                {
                    Message = message,
                    TopicArn = topic,
                };
                await _snsService.PublishAsync(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task SendUploadNotification(string message)
        {
            try
            {
                var request = new PublishRequest
                {
                    Message = message,
                    TopicArn = TopicArn,
                };
                await _snsService.PublishAsync(request);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}