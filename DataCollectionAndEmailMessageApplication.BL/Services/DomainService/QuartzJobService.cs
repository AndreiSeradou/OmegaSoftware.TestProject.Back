﻿using DataCollectionAndEmailMessageApplication.BL.Interfaces.Services;
using DataCollectionAndEmailMessageApplication.BL.Models.DTOs;
using DataCollectionAndEmailMessageApplication.BL.Models.Jobs;
using Quartz;

namespace DataCollectionAndEmailMessageApplication.BL.Services.DomainService
{
    public class QuartzJobService : IQuartzJobService
    {
        private readonly ISchedulerFactory _schedulerFactory;
        private IScheduler _scheduler { get; set; }

        public QuartzJobService(ISchedulerFactory schedulerFactory)
        {
            _schedulerFactory = schedulerFactory;
        }

        public async Task CreateJobAsync(WheatherSubscriptionBLModel model)
        {
            _scheduler = await _schedulerFactory.GetScheduler();

            await _scheduler.Start();

            var trigger = TriggerBuilder.Create()
                .WithIdentity(model.Id.ToString(), model.UserName).WithCronSchedule(model.CronParams).Build();

            var jobDetail = JobBuilder.Create<WheatherJob>()
                 .UsingJobData("City", model.City).UsingJobData("Date", model.Date).WithIdentity(model.Id.ToString(), model.UserName).Build();

            await _scheduler.ScheduleJob(jobDetail, trigger);
        }

        public void DeleteJob(WheatherSubscriptionBLModel model)
        {
            _scheduler.UnscheduleJob(new TriggerKey(model.Id.ToString(), model.UserName));
            _scheduler.DeleteJob(new JobKey(model.Id.ToString(), model.UserName));
        }

        public async Task UpdateJobAsync(WheatherSubscriptionBLModel model)
        {
            DeleteJob(model);
            await CreateJobAsync(model);
        }

        public async Task CreateJobAsync(FootballSubscriptionBLModel model)
        {
            _scheduler = await _schedulerFactory.GetScheduler();

            await _scheduler.Start();

            var trigger = TriggerBuilder.Create()
                .WithIdentity(model.Id.ToString(), model.UserName).WithCronSchedule(model.CronParams).Build();

            var jobDetail = JobBuilder.Create<FootballJob>()
                 .WithIdentity(model.Id.ToString(), model.UserName).Build();

            await _scheduler.ScheduleJob(jobDetail, trigger);
        }

        public async Task UpdateJobAsync(FootballSubscriptionBLModel model)
        {
            DeleteJob(model);
            await CreateJobAsync(model);
        }

        public void DeleteJob(FootballSubscriptionBLModel model)
        {
            _scheduler.UnscheduleJob(new TriggerKey(model.Id.ToString(), model.UserName));
            _scheduler.DeleteJob(new JobKey(model.Id.ToString(), model.UserName));
        }

        public async Task CreateJobAsync(GoogleTranslateSubscriptionBLModel model)
        {
            _scheduler = await _schedulerFactory.GetScheduler();

            await _scheduler.Start();

            var trigger = TriggerBuilder.Create()
                .WithIdentity(model.Id.ToString(), model.UserName).WithCronSchedule(model.CronParams).Build();

            var jobDetail = JobBuilder.Create<GoogleTranslateJob>()
                 .WithIdentity(model.Id.ToString(), model.UserName).Build();

            await _scheduler.ScheduleJob(jobDetail, trigger);
        }

        public async Task UpdateJobAsync(GoogleTranslateSubscriptionBLModel model)
        {
            DeleteJob(model);
            await CreateJobAsync(model);
        }

        public void DeleteJob(GoogleTranslateSubscriptionBLModel model)
        {
            _scheduler.UnscheduleJob(new TriggerKey(model.Id.ToString(), model.UserName));
            _scheduler.DeleteJob(new JobKey(model.Id.ToString(), model.UserName));
        }
    }
}
