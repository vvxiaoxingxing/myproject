using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CrawlerJob
{
    /// <summary>
    /// 服务程序--只要程序启动就会执行的服务
    /// </summary>
    public class QuartzService : IHostedService
    {
        private readonly ILogger _logger;
        //private readonly ISchedulerCenter _schedulerCenter;
        //private readonly IQuartzJobBll _quartzJobBll;

        public QuartzService(ILogger<QuartzService> logger
            //, ISchedulerCenter schedulerCenter
            //, IQuartzJobBll quartzJobBll
            )
        {
            _logger = logger;
            //_schedulerCenter = schedulerCenter;
            //_quartzJobBll = quartzJobBll;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("开始Quartz调度...");
            //await _quartzJobBll.RestoreAllRuningJobs();
            //var jobList = await _quartzJobBll.GetAllJobList();
            //foreach (var job in jobList)
            //{
            //    try
            //    {
            //        var isOk = CronExpression.IsValidExpression(job.CornExpression);
            //        if (!isOk)
            //        {
            //            _logger.LogError($"Corn表达式【job.CornExpression】无效");
            //            continue;
            //        }
            //        JobKey jobKey = new JobKey(job.JobName, job.JobGroupName);
            //        IDictionary<string, object> dic = new Dictionary<string, object>();
            //        dic.Add("JobId", job.Id);
            //        JobDataMap dataMap = new JobDataMap(dic);
            //        var trigger = TriggerBuilder.Create()
            //                     .WithDescription(job.Desc)
            //                     .WithIdentity(job.JobName, job.JobGroupName)
            //                     .WithSchedule(CronScheduleBuilder.CronSchedule(job.CornExpression))
            //                     .StartAt(job.BeginTime)
            //                     .EndAt(job.EndTime)
            //                     .Build();
            //        await _schedulerCenter.AddScheduleJobAsync(typeof(HttpJob), jobKey, dataMap, trigger);
            //    }
            //    catch (Exception ex)
            //    {
            //        _logger.LogError($"{ex}");
            //    }
            //}
            //await _schedulerCenter.StartScheduleAsync();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("停止Quartz调度...");
            //await _schedulerCenter.StopScheduleAsync();
        }
    }
}
