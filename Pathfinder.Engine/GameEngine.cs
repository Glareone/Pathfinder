using System;
using System.Threading.Tasks;

namespace Pathfinder.Engine
{
    public class GameEngine
    {
        /// <summary>
        /// Plays a game
        /// </summary>
        public void PlayGame(GameEngineInvokerParameters gameEngineInvokerParameters, GameEngineParameters gameEngineParameters)
        {
            var task = new Task(() =>
                {
                    var gameEngineDomain = AppDomain.CreateDomain("GameEngineDomain");
                    try
                    {
                        var assembly = gameEngineDomain.Load(typeof(GameEngineWorkflowInvoker).Assembly.GetName());
                        var gameEngineWorkflowInvoker = (GameEngineWorkflowInvoker)assembly.CreateInstance(typeof(GameEngineWorkflowInvoker).FullName);
                        gameEngineWorkflowInvoker.InvokeWorkflow(gameEngineInvokerParameters, gameEngineParameters);
                    }
                    finally
                    {
                        AppDomain.Unload(gameEngineDomain);
                    }
                });
            task.Start();
        }
    }
}