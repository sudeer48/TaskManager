using System;

using Phonix.CrossCutting.Logging;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;

namespace Phonix.Application
{
    public abstract class BaseApplication : IBaseApplication, IDisposable
    {
        private readonly IConfiguration configuration;

        public BaseApplication(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public BaseApplication(IConfiguration configuration, IDistributedCache redisCache)
        {
            this.configuration = configuration;
        }

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                }
                this.disposedValue = true;
            }
        }

        public void Dispose()
        {
            this.Dispose(true); // TODO: uncomment the following line if the finalizer is overridden above.// GC.SuppressFinalize(this);
        }
    }
}
