namespace Pathfinder.Domain.Entities
{
    public class Map : DomainEntity
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Map"/> class
        /// </summary>
        public Map()
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Map"/> class
        /// </summary>
        public Map(string name, byte[] image, byte[] content)
        {
            Name = name;
            Image = image;
            Content = content;
        }

        /// <summary>
        /// Map's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Image
        /// </summary>
        public byte[] Image { get; set; }

        /// <summary>
        /// Content
        /// </summary>
        public byte[] Content { get; set; }

        /// <summary>
        /// Saves instance
        /// </summary>
        public override void Save()
        {
            DomainContext.Instance.RepositoryFactory
                .GetMapRepository()
                .Save(this);
        }
    }
}