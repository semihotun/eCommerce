using System;
using System.Collections.Generic;
using System.Text;
namespace Business.Services.ShowcaseAggregate.ShowcaseServices.ShowcaseServiceModel
{
    public class DeleteShowCase
    {
        public DeleteShowCase(int ıd)
        {
            Id = ıd;
        }
        public DeleteShowCase()
        {
        }
        public int Id { get; set; }
    }
}
