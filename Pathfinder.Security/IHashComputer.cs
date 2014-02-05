namespace Pathfinder.Security
{
    public interface IHashComputer
    {
        /// <summary>
        /// Computes hash
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        string ComputeHash(string input);
    }
}