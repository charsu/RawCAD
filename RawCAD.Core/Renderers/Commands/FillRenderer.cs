using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RawCAD.Core.Models;
using RawCAD.Core.Models.Commands;

namespace RawCAD.Core.Renders.Commands {
   public class FillRenderer : ICommandRenderer {
      public const char LINE_VERTICAL = '|';
      public const char LINE_HORIZONTAL = '-';

      public Task Render(ICommandDto input, char[] buffer, Rectangle screen, CancellationToken cancellationToken) {
         var canvas = input as CanvasCommandDto;
         int sWidth = screen.Width;
         int sHeight = screen.Height;
         if (canvas != null) {
            // we consider that a new canvas will need to reset anything that was before 
            for (int i = 0; i < sHeight; i++) {
               for (int j = 0; j < sWidth; j++) {

                  // index inside the buffer
                  var idx = i * sWidth + j;
                  // reset prev value 
                  buffer[idx] = char.MinValue;

                  // is within the expected bounds 
                  if ((i < canvas.Height) && (j < canvas.Width)) {
                     switch (canvas) {
                        case var c when (j < c.Width) && (i == 0 || i == c.Height - 1): {
                              buffer[idx] = LINE_HORIZONTAL;
                           }
                           break;
                        case var c when (j == 0 || j == c.Width - 1) && (i < c.Height): {
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
