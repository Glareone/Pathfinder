namespace Pathfinder.Domain.Repository
{
    public interface IContentRepository
    {
        /// <summary>
        /// Gets image by path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        byte[] GetImage(string path);
    }
}