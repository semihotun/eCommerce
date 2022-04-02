using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.ShowcaseAggregate.ShowcaseServices.ShowcaseServiceModel
{
    public class GetShowcase
    {
        public GetShowcase(int ıd)
        {
            Id = ıd;
        }

        public int Id { get; set; }
    }
}
