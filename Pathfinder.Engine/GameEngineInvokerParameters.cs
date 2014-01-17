namespace Pathfinder.Engine
{
    public class GameEngineInvokerParameters
    {
        /// <summary>
        /// Initializes a new instance of <see cref="GameEngineInvokerParameters"/> class
        /// </summary>
        public GameEngineInvokerParameters()
        {
            TracingLevel = TracingLevel.Debug;
        }

        /// <summary>
        /// Tracing level
        /// </summary>
        public TracingLevel TracingLevel { get; set; }
    }
}