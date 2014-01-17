namespace Pathfinder.Dependency
{
    public interface IDependencyResolver
    {
        /// <summary>
        /// Resolves type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T Resolve<T>();

        /// <summary>
        /// Registers implementation
        /// </summary>
        /// <typeparam name="TDeclaration"></typeparam>
        /// <typeparam name="TImpementation"></typeparam>
        /// <returns></returns>
        IDependencyResolver Register<TDeclaration, TImpementation>();
    }
}
