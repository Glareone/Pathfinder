﻿namespace Pathfinder.Dependency
{
    public interface IDependencyResolver
    {
        /// <summary>
        /// Resolves type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T Resolve<T>();
    }
}
