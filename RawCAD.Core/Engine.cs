using System;
using System.Threading;
using System.Threading.Tasks;

namespace RawCAD.Core {
   public class Engine : IEngine {

      internal bool IsRunning { get; set; } = false;

      public Task Run(CancellationToken cancellationToken) {
         // set the internal state to running ...
         IsRunning = true;

         try {
            while (IsRunning) {
               cancellationToken.ThrowIfCancellationRequested();

               // display 

               // read key 

               // process key ?!?

            }
         }
         catch (Exception ex) {
            // not good :(

         }

         // all GOOD 
         return Task.FromResult(0);
      }

      #region IDisposable
      public void Dispose() {
      }
      #endregion IDisposable
   }
}
