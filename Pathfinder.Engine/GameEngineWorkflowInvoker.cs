using System;
using System.Activities;
using System.Activities.Tracking;
using System.Collections.Generic;

using Pathfinder.Dependency;
using Pathfinder.Engine.Tracking;
using Pathfinder.Log;

namespace Pathfinder.Engine
{
    public class GameEngineWorkflowInvoker : MarshalByRefObject
    {
        /// <summary>
        /// Invokes workflow
        /// </summary>
        /// <param name="gameEngineInvokerParameters"></param>
        /// <param name="gameEngineParameters"></param>
        public void InvokeWorkflow(GameEngineInvokerParameters gameEngineInvokerParameters, GameEngineParameters gameEngineParameters)
        {
            var workflowInvoker = new WorkflowInvoker(new GameEngineWorkflow());
            workflowInvoker.Extensions.Add(CreateTrackingParticipant(gameEngineInvokerParameters));
            //workflowInvoker.Invoke(CreateWorkflowArguments(gameEngineParameters));
            DI.Resolve<ILog>().Debug("Bla");
        }

        /// <summary>
        /// Creates workflow arguments
        /// </summary>
        /// <returns></returns>
        protected Dictionary<string, object> CreateWorkflowArguments(GameEngineParameters gameEngineParameters)
        {
            return new Dictionary<string, object>
                    {
                        { "gameEngineParameters",  gameEngineParameters }
                    };
        }

        /// <summary>
        /// Creates tracking participant
        /// </summary>
        /// <returns></returns>
        protected static TrackingParticipant CreateTrackingParticipant(GameEngineInvokerParameters gameEngineInvokerParameters)
        {
            var logTrackingParticipant = new LogTrackingParticipant(DI.Resolve<ILog>())
            {
                TrackingProfile = new TrackingProfile
                {
                    Name = "DefaultTrackingProfile",
                }
            };

            switch (gameEngineInvokerParameters.TracingLevel)
            {
                case TracingLevel.Debug:
                    logTrackingParticipant.TrackingProfile
                        .Queries
                        .Add(new ActivityStateQuery
                        {
                            States = { "*" }
                        });

                    logTrackingParticipant.TrackingProfile
                        .Queries
                        .Add(new WorkflowInstanceQuery
                        {
                            States = { "*" }
                        });
                    break;
            }

            logTrackingParticipant.TrackingProfile
                .Queries
                .Add(new CustomTrackingQuery
                {
                    ActivityName = "*",
                    Name = "*"
                });

            return logTrackingParticipant;
        }
    }
}