using System.Collections.Generic;
namespace Core.Utilities.Email
{
    public class EmailMessage
    {
        public List<string> ToAddresses { get; set; }
        public string Content { get; set; }
    }
}
