using System.Collections.Generic;
using Pathfinder.Domain.Entities;
using Pathfinder.Domain.Repository;

namespace Pathfinder.Data.Repository
{
    public class ArtifactRepository : RepositoryBase<Artifact>, IArtifactRepository
    {
        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        public override List<Artifact> GetAll()
        {
            return new List<Artifact>
                {
                    new Artifact
                        {
                            Id = 1,
                            Name = "Leather boots",
                            SpeedBonus = .20,
                            Cost = 100,
                            IconPath = "Artifacts.artifact_1.png",
                            Weight = 2.08
                        },
                    new Artifact
                        {
                            Id = 2,
                            Name = "Leather mail",
                            SpeedBonus = -.10,
                            Cost = 50,
                            IconPath = "Artifacts.artifact_2.png",
                            Weight = 6.90
                        },
                    new Artifact
                        {
                            Id = 3,
                            Name = "Traveller's journal",
                            VisionBonus = .80,
                            Cost = 150,
                            IconPath = "Artifacts.artifact_3.png",
                            Weight = .86
                        },
                    new Artifact
                        {
                            Id = 4,
                            Name = "Signet Ring",
                            Cost = 200,
                            IconPath = "Artifacts.artifact_4.png",
                            Weight = .01
                        },
                    new Artifact
                        {
                            Id = 5,
                            Name = "Silver ring",
                            Cost = 100,
                            IconPath = "Artifacts.artifact_5.png",
                            Weight = .01
                        },
                    new Artifact
                        {
                            Id = 6,
                            Name = "Jasper",
                            Cost = 130,
                            IconPath = "Artifacts.artifact_6.png",
                            Weight = .5
                        },
                    new Artifact
                        {
                            Id = 7,
                            Name = "Lazuli",
                            SpeedBonus = .20,
                            Cost = 100,
                            IconPath = "Artifacts.artifact_7.png",
                            Weight = .55
                        },
                    new Artifact
                        {
                            Id = 8,
                            Name = "Sapphire",
                            SpeedBonus = .20,
                            Cost = 100,
                            IconPath = "Artifacts.artifact_8.png",
                            Weight = .5
                        },
                    new Artifact
                        {
                            Id = 9,
                            Name = "Potion of Poison",
                            SpeedBonus = -.40,
                            VisionBonus = -.20,
                            Cost = 100,
                            IconPath = "Artifacts.artifact_9.png",
                            Weight = .02
                        },
                    new Artifact
                        {
                            Id = 10,
                            Name = "Potion of Speed",
                            SpeedBonus = .10,
                            Cost = 50,
                            IconPath = "Artifacts.artifact_10.png",
                            Weight = .02
                        },
                    new Artifact
                        {
                            Id = 11,
                            Name = "Axe",
                            SpeedBonus = .10,
                            Cost = 120,
                            IconPath = "Artifacts.artifact_11.png",
                            Weight = 3.11
                        },
                    new Artifact
                        {
                            Id = 12,
                            Name = "Battle axe",
                            SpeedBonus = .20,
                            Cost = 200,
                            IconPath = "Artifacts.artifact_12.png",
                            Weight = 4.66
                        },
                    new Artifact
                        {
                            Id = 13,
                            Name = "Crossbow",
                            SpeedBonus = .15,
                            Cost = 180,
                            IconPath = "Artifacts.artifact_13.png",
                            Weight = 4.59
                        },
                    new Artifact
                        {
                            Id = 14,
                            Name = "Bow",
                            SpeedBonus = .10,
                            Cost = 120,
                            IconPath = "Artifacts.artifact_14.png",
                            Weight = 2.08
                        },

                };
        }
    }
}