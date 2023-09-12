namespace API.SQS
{
    public  interface IQueueService
    {
        Task PushQueueItem(string message);
    }
}
