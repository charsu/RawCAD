using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RawCAD.Core.Models;
using RawCAD.Core.Models.Commands;

namespace RawCAD.Core.Renders.Commands {
   public class SquareRenderer : ICommandRenderer {
      public const char LINE = 'x';

      public Task Render(ICommandDto input, char[] buffer, Rectangle screen, CancellationToken cancellationToken) {
         var square = input as SquareCommandDto;
         if (square != null) {
            // we consider that a new canvas will need to reset anything that was before 
            for (int i = square.Y1; i < square.Y2; i++) {
               for (int j = square.X1; j < square.X2; j++) {

                  // index inside the buffer
                  var idx = i * screen.Width + j;

                  // protect against buffer overflow
                  if (idx >= buffer.Length)
                     break;

                  // is within the expected bounds 
                  switch (square) {
                     case var c when (j < c.X2) && (i == c.Y1 || i == c.Y2 - 1):
                     case var x when (j == x.X1 || j == x.X2 - 1) && (i < x.Y2): {
                           buffer[idx] = LINE;
                        }
                        break;
                  }
               }
            }
         }

         return Task.FromResult(0);
      }
   }
}
