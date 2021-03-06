﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RawCAD.Core.Models.Commands;
using RawCAD.Core.Parsers;
using RawCAD.Core.Renders;

namespace RawCAD.Core {
   public class Engine : IEngine {
      internal bool IsRunning { get; set; } = false;
      private readonly ICommandEngine _commandEngine;
      private readonly IScreen _screen;

      public Engine(ICommandEngine commandEngine, IScreen screen) {
         _commandEngine = commandEngine;
         _screen = screen;
      }

      public async Task Run(CancellationToken cancellationToken) {
         // set the internal state to running ...
         IsRunning = true;
         string input = string.Empty;

         try {
            while (IsRunning) {
               cancellationToken.ThrowIfCancellationRequested();

               // display 
               await _screen.Render(cancellationToken);

               // get and process user input
               var command = await _commandEngine.GetNextCommand(cancellationToken).ConfigureAwait(false);

               // try to update the screen 
               await _screen.Update(command, cancellationToken);

               // process the exit command
               if (command.WasHandled && command.Output is QuitCommandDto) {
                  IsRunning = false;
               }
            }
         }
         catch (Exception e) {
            // not good :(
            throw;
         }

         // all GOOD 
      }

      #region IDisposable
      public void Dispose() {
      }
      #endregion IDisposable
   }
}
