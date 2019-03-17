using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RawCAD.Core.Renders {
   public class Screen : IScreen {
      public const int MAX_SCREEN_SIZE = 1024;
      public const string COMMAND_MESSAGE = "enter command: ";

      public Screen(int swidth, int sheight) {
         ScreenSize = new Rectangle(0, 0, swidth, sheight);
         buffer = new char[swidth * sheight];
      }

      public Rectangle ScreenSize { get; private set; }
      public Rectangle? CanvasSize { get; private set; }

      public char[] buffer;

      public async Task Render(CancellationToken cancellationToken) {
         // clean the screen 
         Console.Clear();

         // draw the table 
         Console.SetCursorPosition(0, 1);
         Console.Write(buffer);

         // draw the message last so tat the cursor is in the right place
         Console.SetCursorPosition(0, 0);
         Console.Write(COMMAND_MESSAGE);
      }
   }
}
