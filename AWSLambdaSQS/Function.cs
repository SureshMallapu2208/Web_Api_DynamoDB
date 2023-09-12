using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;
using API.S3;
using Amazon.SimpleNotificationService;
using Newtonsoft.Json.Linq;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AWSLambdaSQS;

public class Function
{

    private readonly INotificationService _amazonSimpleNotificationService;

    private readonly IAmazonS3Service _amazonS3;
    /// <summary>
    /// Default constructor. This constructor is used by Lambda to construct the instance. When invoked in a Lambda environment
    /// the AWS credentials will come from the IAM role associated with the function and the AWS region will be set to the
    /// region the Lambda function is executed in.
    /// </summary>
    //public Function()
    //{
    //    //_amazonSimpleNotificationService = amazonSimpleNotificationService;
    //    //_amazonS3 = amazonS3;
    //}

    public Function()
    {
     
    }

    // Injection ctor
    public Function(IAmazonS3Service amazonS3)
    {
        _amazonS3 = amazonS3;
    }

    /// <summary>
    /// This method is called for every Lambda invocation. This method takes in an SQS event object and can be used 
    /// to respond to SQS messages.
    /// </summary>

    /// <param name="evnt"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task FunctionHandler(SQSEvent evnt, ILambdaContext context)
    {
        await _amazonS3.UploadFileAsync();

    }

    private async Task ProcessMessageAsync(SQSEvent.SQSMessage message, ILambdaContext context)
    {
        context.Logger.LogInformation($"Processed message {message.Body}");

        // TODO: Do interesting work based on the new message
        await Task.CompletedTask;
    }
}