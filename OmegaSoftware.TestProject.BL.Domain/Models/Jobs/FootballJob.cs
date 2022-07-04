﻿using OmegaSoftware.TestProject.BL.Domain.Interfaces.Services;
using OmegaSoftware.TestProject.BL.Domain.Models.DTOs;
using OmegaSoftware.TestProject.Configuration;
using Quartz;
using System.Text;


namespace OmegaSoftware.TestProject.BL.Domain.Models.Jobs
{
    public class FootballJob : IJob
    {
        private readonly IEmailSenderService _emailSenderService;
        private readonly IApiSenderService<FootballSubscriptionBLModel, string> _apiSenderService;

        public FootballJob(IEmailSenderService emailSenderService, IApiSenderService<FootballSubscriptionBLModel, string> apiSenderService)
        {
            _emailSenderService = emailSenderService;
            _apiSenderService = apiSenderService;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var jobData = context.JobDetail.JobDataMap;

            var email = jobData.GetString(ApplicationConfiguration.JobMainParam);

            var apiResult = _apiSenderService.SendOnApi();

            await _emailSenderService.Send(email, apiResult);
        }
    }
}