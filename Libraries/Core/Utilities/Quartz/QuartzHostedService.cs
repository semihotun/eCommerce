﻿using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Spi;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
namespace Core.Utilities.Quartz
{
    public class QuartzHostedService : IHostedService
    {
        private readonly ISchedulerFactory _schedulerFactory;
        private readonly IJobFactory _jobFactory;
        private readonly IEnumerable<JobModel> _myJob;
        public QuartzHostedService(ISchedulerFactory schedulerFactory, IJobFactory jobFactory, IEnumerable<JobModel> myJob)
        {
            _schedulerFactory = schedulerFactory;
            _jobFactory = jobFactory;
            _myJob = myJob;
        }
        public IScheduler Scheduler { get; set; }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            // Zamanlayıcı
            Scheduler = await _schedulerFactory.GetScheduler(cancellationToken);
            Scheduler.JobFactory = _jobFactory;
            foreach (var myJob in _myJob)
            {
                var job = CreateJob(myJob);
                var trigger = CreateTrigger(myJob);
                // Job ile Trigger ı bir biri ile eşleştiriyoruz.
                await Scheduler.ScheduleJob(job, trigger, cancellationToken);
            }
            await Scheduler.Start(cancellationToken);
        }
        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Scheduler?.Shutdown(cancellationToken);
        }
        private static IJobDetail CreateJob(JobModel myJob)
        {
            var type = myJob.Type;
            return JobBuilder.Create(type)
                .WithIdentity(type.FullName)
                .WithDescription(type.Name).Build();
        }
        private static ITrigger CreateTrigger(JobModel myJob)
        {
            return TriggerBuilder.Create()
                .WithCronSchedule(myJob.Expression)//Gönderdiğimiz zamanlama
                .WithIdentity($"{myJob.Type.FullName}")
                .WithDescription(myJob.Expression).Build();
        }
    }
}
