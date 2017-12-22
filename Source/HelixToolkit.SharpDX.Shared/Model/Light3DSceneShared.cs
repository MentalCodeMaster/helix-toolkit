﻿/*
The MIT License (MIT)
Copyright (c) 2018 Helix Toolkit contributors
*/
using SharpDX;
#if NETFX_CORE
namespace HelixToolkit.UWP.Model
#else
namespace HelixToolkit.Wpf.SharpDX.Model
#endif
{
    using global::SharpDX.Direct3D11;
    using ShaderManager;
    using Shaders;
    using System;
    using Utilities;

    /// <summary>
    /// Used to hold shared variables for Lights per scene
    /// </summary>
    public sealed class Light3DSceneShared : IDisposable
    {
        public readonly ILightsBufferProxy<LightStruct> LightModels = new LightsBufferModel();

        private int lightCount = 0;
        public int LightCount
        {
            get { return lightCount; }
            set
            {
                lightCount = value;
            }
        }

        private IBufferProxy buffer;
        /// <summary>
        /// 
        /// </summary>
        public Light3DSceneShared(IConstantBufferPool pool)
        {
            buffer = pool.Register(DefaultConstantBufferDescriptions.LightCB);    
        }

        public void UploadToBuffer(DeviceContext context)
        {
            LightModels.UploadToBuffer(buffer, context);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    buffer = null;
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Light3DSceneShared() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
