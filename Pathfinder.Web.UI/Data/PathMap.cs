namespace Pathfinder.Web.UI.Data
{
    public sealed class PathMap
    {
        /// <summary>
        /// Initializes a new instance of <see cref="PathMap"/> class
        /// </summary>
        private PathMap()
        {
        }

        /// <summary>
        /// Directory name
        /// </summary>
        public string Directory { get; set; }

        /// <summary>
        /// Name of file
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// Converts to map
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static PathMap ToMap(string path)
        {
            var delimiter = path.LastIndexOf('/');

            return new PathMap
            {
                Directory = path.Substring(0, delimiter),
                Filename = path.Substring(delimiter + 1)
            };
        }
    }
}