using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace Pathfinder.Dependency.CastleWindsor
{
    public class CastleWindsorDependencyResolver : IDependencyResolver
    {
        /// <summary>
        /// Initializes a new instance of <see cref="CastleWindsorDependencyResolver"/> class
        /// </summary>
        public CastleWindsorDependencyResolver()
        {
            Container = new WindsorContainer();
        }

        /// <summary>
        /// Windsor container
        /// </summary>
        protected IWindsorContainer Container { get; set; }

        /// <summary>
        /// Resolves type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

        /// <summary>
        /// Registers implementation
        /// </summary>
        /// <typeparam name="TDeclaration"></typeparam>
        /// <typeparam name="TImpementation"></typeparam>
        /// <returns></returns>
        public IDependencyResolver Register<TDeclaration, TImpementation>()
        {
            Container.Register(Component.For(typeof(TDeclaration)).ImplementedBy(typeof(TImpementation)));

            return this;
        }

        /// <summary>
        /// Registers implementation
        /// </summary>
        /// <typeparam name="TDeclaration"></typeparam>
        /// <typeparam name="TImpementation"></typeparam>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IDependencyResolver Register<TDeclaration, TImpementation>(object parameters)
        {
            Container
                .Register(Component.For(typeof(TDeclaration))
                .ImplementedBy(typeof(TImpementation)).DependsOn(parameters));

            return this;
        }
    }
}
