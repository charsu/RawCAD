using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RawCAD.Core.Models.Commands;
using RawCAD.Core.Parsers;

namespace RawCAD.Core {
   public class Engine : IEngine {

      public Engine(ICommandEngine commandEngine) {
         _commandEngine = commandEngine;
      }

      internal bool IsRunning { get; set; } = false;
      private readonly ICommandEngine _commandEngine;

      public async Task Run(CancellationToken cancellationToken) {
         // set the internal state to running ...
         IsRunning = true;
         string input = string.Empty;


         try {
            while (IsRunning) {
               cancellationToken.ThrowIfCancellationRequested();

               // display 
               Console.WriteLine($"echo:{input}");


               // read key 
               var command = await _commandEngine.GetNextCommand(cancellationToken).ConfigureAwait(false);

               // process key ?!?

               // process the exit command
               if (command.WasHandled && command.Output is QuitCommandDto) {
                  IsRunning = false;
               }
            }
         }
         catch (Exception) {
            // not good :(

         }

         // all GOOD 
      }

      #region IDisposable
      public void Dispose() {
      }
      #endregion IDisposable
   }
}
