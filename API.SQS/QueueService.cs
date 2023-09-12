using Amazon.SQS;
using Amazon.SQS.Model;

namespace API.SQS
{
    public class QueueService : IQueueService
    {
        private static string _queueUrl = "https://sqs.ap-southeast-2.amazonaws.com/878770420070/simple-queue";
        private readonly IAmazonSQS _amazonSQS;
        public QueueService(IAmazonSQS amazonSQS)
        {
            _amazonSQS = amazonSQS;
        }
        public async Task PushQueueItem(string message)
        {

            var req = new SendMessageRequest
            {
                MessageBody = message,
                QueueUrl = _queueUrl

            };
            await _amazonSQS.SendMessageAsync(req);
        }
    }
}