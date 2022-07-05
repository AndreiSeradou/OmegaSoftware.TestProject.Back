﻿using OmegaSoftware.TestProject.BL.Domain.Interfaces.Services;
using OmegaSoftware.TestProject.BL.Domain.Models.DTOs;
using OmegaSoftware.TestProject.Configuration;
using Quartz;
using System.Text;

namespace OmegaSoftware.TestProject.BL.Domain.Models.Jobs
{
    public class GoogleTranslateJob : IJob
    {
        private readonly IEmailSenderService _emailSenderService;
        private readonly IApiSenderService<GoogleTranslateSubscriptionDTOs, string> _apiSenderService;

        public GoogleTranslateJob(IEmailSenderService emailSenderService, IApiSenderService<GoogleTranslateSubscriptionDTOs, string> apiSenderService)
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