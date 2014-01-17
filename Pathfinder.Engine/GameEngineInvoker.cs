using System;
using System.Activities;
using System.Activities.Tracking;
using System.Collections.Generic;

using Pathfinder.Dependency;
using Pathfinder.Engine.Tracking;
using Pathfinder.Log;

namespace Pathfinder.Engine
{
    public class GameEngineInvoker : MarshalByRefObject
    {
        /// <summary>
        /// Plays a game
        /// </summary>
        public void PlayGame(GameEngineInvokerParameters gameEngineInvokerParameters, GameEngineParameters gameEngineParameters)
        {
            var workflowApplication = new WorkflowApplication(new GameEngineWorkflow(), CreateWorkflowArguments(gameEngineParameters));

            workflowApplication.Extensions.Add(CreateTrackingParticipant(gameEngineInvokerParameters));
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
            var logTrackingParticipant = new LogTrackingParticipant(DI.Resolver.Resolve<ILog>())
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