using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;

namespace Web_Api_DynamoDB
{
    [DynamoDBTable("users")]
    public class User
    {
        [DynamoDBHashKey]
        public string? Id { get; set; }

        [DynamoDBProperty]
        public string? Name { get; set; }

        [DynamoDBProperty]
        public string? Mobile { get; set; }

        [DynamoDBProperty]
        public string? Email { get; set; }

    }
}
