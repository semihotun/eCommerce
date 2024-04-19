using System;

namespace Entities.RequestModel.AdminAggregate.AdminAuths
{
    public class LogOutReqModel
    {
        public Guid Id { get; set; }
        public LogOutReqModel()
        {
        }
        public LogOutReqModel(Guid ıd)
        {
            Id = ıd;
        }
    }
}
