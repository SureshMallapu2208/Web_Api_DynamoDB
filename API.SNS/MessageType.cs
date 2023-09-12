using System.ComponentModel;

namespace API.SNS
{
    public enum MessageType
    {
        [Description("Transactional")]
        Transactional,
        [Description("Promotional")]
        Promotional
    }
}
