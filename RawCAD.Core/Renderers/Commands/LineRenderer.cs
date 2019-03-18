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
            if (mx == 0) {
               // is vertical 
               for (int y = line.Y1; y <= line.Y2; y++) {
                  var x = line.X1;
                  var idx = y * screen.Width + x;
                  buffer[idx] = LINE;
               }
            }
            else if (my == 0) {
               // is horizontal 
               for (int x = line.X1; x <= line.X2; x++) {
                  var y = line.Y1;
                  var idx = y * screen.Width + x;
                  buffer[idx] = LINE;
               }
            }
            else {
               // we have a slope 
               for (int x = line.X1; x <= line.X2; x++) {
                  var y = GetY(x, m, line.X1, line.Y1);
                  var idx = y * screen.Width + x;
                  buffer[idx] = LINE;
               }
            }
         }

         return Task.FromResult(0);
      }

      // y − y1 = m(x − x1)
      private int GetY(int x, int m, int x1, int y1) => m * (x - x1) + y1;
      private int GetX(int y, int m, int x1, int y1) => (y - y1) / m - x1;


   }
}
