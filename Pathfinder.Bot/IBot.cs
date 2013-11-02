namespace Pathfinder.Bot
{
    public interface IBot
    {
        /// <summary>
        /// Do turn
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        Direction DoTurn(IGameState state);
    }
}