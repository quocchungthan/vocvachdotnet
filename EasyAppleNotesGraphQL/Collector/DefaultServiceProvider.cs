using System;
namespace EasyAppleNotesGraphQL.Collector
{
    public sealed class DefaultServiceProvider : IServiceProvider
    {
        public object GetService(Type serviceType)
        {
            if (serviceType == null)
                throw new ArgumentNullException(nameof(serviceType));

            try
            {
                Console.WriteLine("Create instance of ", serviceType.FullName);

                return Activator.CreateInstance(serviceType);
            }
            catch (Exception exception)
            {
                throw new Exception($"Failed to call Activator.CreateInstance. Type: {serviceType.FullName}", exception);
            }
        }
    }
}
