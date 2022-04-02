using System;

namespace Core.Utilities.Quartz
{
    public class JobModel
    {
        public JobModel(Type type, string expression)
        {
            Type = type;
            Expression = expression;
        }

        public Type Type { get;  }
        public string Expression { get; set; }
    }
}
