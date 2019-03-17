using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RawCAD.Core.Models;
using RawCAD.Core.Models.Commands;

namespace RawCAD.Core.Renders.Commands {
   public class LineRenderer : ICommandRenderer {
      public const char LINE = 'x';

      public Task Render(ICommandDto input, char[] buffer, Rectangle screen, CancellationToken cancellationToken) {
         var line = input as LineCommandDto;
         if (line != null) {
            var mx = (line.X1 - line.X2);
            var my = (line.Y1 - line.Y2);

            // slope 
            var m = mx == 0 || my == 0 ? 0 : my / mx;

            for (int x = line.Y1; x < line.Y2; x++) {
               var y = GetY(x, m, line.X1, line.Y1);
               var idx = y * screen.Width + x;
               buffer[idx] = LINE;
            }
         }

         return Task.FromResult(0);
      }

      // y − y1 = m(x − x1)
      private int GetY(int x, int m, int x1, int y1) => m * (x - x1) + y1;
   }
}
