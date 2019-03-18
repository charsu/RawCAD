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
      public readonly static List<char> BLOCKERS = new List<char>() { 'x', '|', '-' };

      public async Task Render(ICommandDto input, char[] buffer, Rectangle screen, CancellationToken cancellationToken) {
         var fill = input as FillCommandDto;
         if (fill != null) {
            int sWidth = screen.Width;
            int sHeight = screen.Height;

            await CheckAndFill(fill.X, fill.Y, fill.Color, buffer, screen, cancellationToken).ConfigureAwait(false);
         }
      }

      private async Task CheckAndFill(int x, int y, char color, char[] buffer, Rectangle screen, CancellationToken cancellationToken) {
         cancellationToken.ThrowIfCancellationRequested();

         // recursion break (out of bounds)
         if (x < 0 || y < 0 || x > screen.Width || y > screen.Height) {
            return;
         }

         // try current position 
         var idx = y * screen.Width + x;
         if (idx >= buffer.Length)
            return;

         var currentValue = buffer[idx];
         if (currentValue == color || BLOCKERS.Contains(currentValue)) {
            // end of the road (in this direction)
            return;
         }

         // all good so far , lets leave a mark 
         buffer[idx] = color;

         // expand
         // go left 
         await CheckAndFill(x - 1, y, color, buffer, screen, cancellationToken);
         // go right 
         await CheckAndFill(x + 1, y, color, buffer, screen, cancellationToken);
         // go down 
         await CheckAndFill(x, y - 1, color, buffer, screen, cancellationToken);
         // go up 
         await CheckAndFill(x, y + 1, color, buffer, screen, cancellationToken);
      }
   }
}
