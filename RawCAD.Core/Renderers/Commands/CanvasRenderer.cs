using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RawCAD.Core.Models;
using RawCAD.Core.Models.Commands;

namespace RawCAD.Core.Renders.Commands {
   public class CanvasRenderer : ICommandRenderer {
      public const char LINE_VERTICAL = '|';
      public const char LINE_HORIZONTAL = '-';

      public Task Render(ICommandDto input, char[] buffer, Rectangle screen, CancellationToken cancellationToken) {
         var canvas = input as CanvasCommandDto;
         if (canvas != null) {
            int sWidth = screen.Width;
            int sHeight = screen.Height;
            var cWidth = canvas.Width + 1;
            var cHeigth = canvas.Height + 1;

            // we consider that a new canvas will need to reset anything that was before 
            for (int y = 0; y < sHeight; y++) {
               for (int x = 0; x < sWidth; x++) {

                  // index inside the buffer
                  var idx = y * sWidth + x;

                  // protect against buffer overflow
                  if (idx >= buffer.Length)
                     break;

                  // reset prev value 
                  buffer[idx] = char.MinValue;

                  // is within the expected bounds 
                  if ((x <= cWidth) && (y <= cHeigth)) {
                     switch (canvas) {
                        case var c when (x <= cWidth) && (y == 0 || y == cHeigth): {
                              buffer[idx] = LINE_HORIZONTAL;
                           }
                           break;
                        case var c when (x == 0 || x == cWidth) && (y <= cHeigth): {
                              buffer[idx] = LINE_VERTICAL;
                           }
                           break;
                     }
                  }
               }
            }
         }

         return Task.FromResult(0);
      }
   }
}
