﻿namespace Pathfinder.Domain.Entities
{
    public class Artifact : DomainEntity
    {
        /// <summary>
        /// Name of artifact
        /// </summary>
        public string Name { get;set; }

        /// <summary>
        /// Speed bonus
        /// </summary>
        public double? SpeedBonus { get; set; }

        /// <summary>
        /// Vision bonus
        /// </summary>
        public double? VisionBonus { get; set; }

        /// <summary>
        /// Cost value
        /// </summary>
        public int Cost { get; set; }

        /// <summary>
        /// Weight value
        /// </summary>
        public double Weight { get;set; }

        /// <summary>
        /// Icon path
        /// </summary>
        public string IconPath { get; set; }

        /// <summary>
        /// Saves instance
        /// </summary>
        public override void Save()
        {
            throw new System.NotImplementedException();
        }
    }
}