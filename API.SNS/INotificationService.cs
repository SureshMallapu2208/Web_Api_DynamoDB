using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.SNS
{
    public interface INotificationService
    {
         Task Send(Message message);

    }
}
