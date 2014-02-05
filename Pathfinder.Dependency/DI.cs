namespace Pathfinder.Dependency
{
    public class DI
    {
        /// <summary>
        /// Dependency resolver instance
        /// </summary>
        private static IDependencyResolver Resolver { get; set; }

        /// <summary>
        /// Resolves type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Resolve<T>()
        {
            return Resolver.Resolve<T>();
        }

        /// <summary>
        /// Sets resolver
        /// </summary>
        /// <param name="resolver"></param>
        public static void SetResolver(IDependencyResolver resolver)
        {
            Resolver = resolver;
        }
    }
}