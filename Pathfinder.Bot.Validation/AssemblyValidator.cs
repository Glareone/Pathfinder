using System;
using System.Reflection;

namespace Pathfinder.Bot.Validation
{
    public sealed class AssemblyValidator : IDisposable
    {
        /// <summary>
        /// Validates assembly
        /// </summary>
        /// <param name="rawAssembly"></param>
        public void Validate(byte[] rawAssembly)
        {
            var domain = AppDomain.CreateDomain(typeof(AssemblyValidator).Name);
            try
            {
                Assembly assembly;
                try
                {
                    assembly = domain.Load(rawAssembly);
                }
                catch(Exception)
                {
                    throw new InvalidOperationException("File format is not recognized.");
                }

                var iBot = assembly.GetType(typeof(IBot).FullName);
                if (iBot == null)
                {
                    throw new InvalidOperationException("IBot implementation is not found.");
                }
            }
            finally 
            {
                AppDomain.Unload(domain);
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            
        }
    }
}
