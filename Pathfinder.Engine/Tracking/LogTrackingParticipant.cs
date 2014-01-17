using System;
using System.Activities.Tracking;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Pathfinder.Log;

namespace Pathfinder.Engine.Tracking
{
    public class LogTrackingParticipant : TrackingParticipant
    {
        /// <summary>
        /// Initializes a new instance of <see cref="LogTrackingParticipant"/> class
        /// </summary>
        /// <param name="log"></param>
        public LogTrackingParticipant(ILog log)
        {
            Log = log;
        }

        /// <summary>
        /// Log4net
        /// </summary>
        protected ILog Log { get; private set; }

        /// <summary>
        /// When implemented in a derived class, used to synchronously process the tracking record.
        /// </summary>
        /// <param name="record">The generated tracking record.</param><param name="timeout">The time period after which the provider aborts the attempt.</param>
        protected override void Track(TrackingRecord record, TimeSpan timeout)
        {
            var activityStateRecord = record as ActivityStateRecord;
            if (activityStateRecord != null)
            {
                TraceActivityStateRecord(activityStateRecord);
                return;
            }

            var customTrackingRecord = record as CustomTrackingRecord;
            if (customTrackingRecord != null)
            {
                TraceCustomTracingRecord(customTrackingRecord);
                return;
            }

            var workflowInstanceRecord = record as WorkflowInstanceRecord;
            if (workflowInstanceRecord != null)
            {
                TraceWorkflowInstanceRecord(workflowInstanceRecord);
                return;
            }
        }

        /// <summary>
        /// Traces activity record
        /// </summary>
        /// <param name="record"></param>
        protected void TraceActivityStateRecord(ActivityStateRecord record)
        {
            var trace = string.Format("{0, -6} {1}.{2}", record.Activity.Id, record.Activity.Name, record.State);

            Trace(record.Level, trace);
        }

        /// <summary>
        /// Traces activity record
        /// </summary>
        /// <param name="record"></param>
        protected void TraceCustomTracingRecord(CustomTrackingRecord record)
        {
            Exception exception = null;

            var trace = new StringBuilder()
                    .Append(string.Format("{0, -6} {1}.{2}", record.Activity.Id, record.Activity.Name, record.Name));

            if (record.Data.Any())
            {
                trace.Append(" Data [");
                foreach (var data in record.Data)
                {
                    trace.AppendFormat("{0}:{1},", data.Key, data.Value);
                }

                trace.Remove(trace.Length - 1, 1);

                trace.Append("]");

                if (record.Data.ContainsKey("Exception"))
                {
                    exception = record.Data["Exception"] as Exception;
                }
            }

            Trace(record.Level, trace.ToString(), exception);
        }

        /// <summary>
        /// Traces activity record
        /// </summary>
        /// <param name="record"></param>
        protected void TraceWorkflowInstanceRecord(WorkflowInstanceRecord record)
        {
            var trace = string.Format("{0, -6} {1}.{2}", record.ActivityDefinitionId, record.ActivityDefinitionId, record.State);

            Trace(record.Level, trace);
        }

        /// <summary>
        /// Traces
        /// </summary>
        /// <param name="traceLevel"></param>
        /// <param name="trace"></param>
        /// <param name="exception"></param>
        protected void Trace(TraceLevel traceLevel, string trace, Exception exception = null)
        {
            switch (traceLevel)
            {
                case TraceLevel.Verbose:
                    Log.Debug(trace, exception);
                    break;

                case TraceLevel.Info:
                    Log.Info(trace, exception);
                    break;

                case TraceLevel.Warning:
                    Log.Warn(trace, exception);
                    break;

                case TraceLevel.Error:
                    Log.Error(trace, exception);
                    break;
            }
        }
    }
}