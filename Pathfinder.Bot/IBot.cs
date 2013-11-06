namespace Pathfinder.Bot
{
    public interface IBot
    {
        /// <summary>
        /// Loading step
        /// </summary>
        /// <param name="state"></param>
        void Load(IGameState state);

        /// <summary>
        /// Do turn
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        Direction DoTurn(IGameState state);

        /// <summary>
        /// Unload and free all resources
        /// </summary>
        void Unload();
    }
}