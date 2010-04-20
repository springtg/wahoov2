using System;
using System.Collections.Generic;
using System.Text;
using Quartz;

namespace HL7ServerTransfer.Job
{
    class ScheduleJob : IJob
    {
        public void Execute(JobExecutionContext context)
        {
            try
            {                
                ISchedulerFactory schedFact = new Quartz.Impl.StdSchedulerFactory();
                IScheduler sched = schedFact.GetScheduler();
                JobDataMap dataMap = context.MergedJobDataMap;

                DateTime timeStart = dataMap.GetDateTime("TimeStart");
                DateTime timeEnd = dataMap.GetDateTime("TimeEnd");
                int timeRepeat = dataMap.GetInt("TimeRepeat");

                JobDetail jobDetail = sched.GetJobDetail("ExecuteJob", "Eroup1");
                if (jobDetail == null)
                {
                    jobDetail = new JobDetail("ExecuteJob", "Eroup1", typeof(DownloadJob));
                    SimpleTrigger trigger = new SimpleTrigger("ExecuteTrigger", timeStart.ToUniversalTime(), timeEnd.ToUniversalTime(), SimpleTrigger.RepeatIndefinitely, TimeSpan.FromSeconds(timeRepeat));
                    sched.ScheduleJob(jobDetail, trigger);
                }
                else
                {
                    foreach (Trigger tri in sched.GetTriggersOfJob("ExecuteJob", "Eroup1"))
                    {
                        sched.UnscheduleJob(tri.Name, tri.Group);
                    }
                    SimpleTrigger newtrigger = new SimpleTrigger("ExecuteTrigger", "Eroup1", "ExecuteJob", "Eroup1", timeStart.ToUniversalTime(), timeEnd.ToUniversalTime(), SimpleTrigger.RepeatIndefinitely, TimeSpan.FromSeconds(timeRepeat));
                    sched.ScheduleJob(jobDetail, newtrigger);
                }
            }
            catch (Exception ex)
            {                
            }
        }
    }
}
