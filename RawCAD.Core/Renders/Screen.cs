using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RawCAD.Core.Models;
using RawCAD.Core.Renders.Commands;

namespace RawCAD.Core.Renders {
   public class Screen : IScreen {
      public const int MAX_SCREEN_SIZE = 1024;
      public const string COMMAND_MESSAGE = "enter command: ";

      public Screen(int swidth, int sheight, List<ICommandRenderer> commandRenderers) {
         _screenSize = new Rectangle(0, 0, swidth, sheight);
         _buffer = new char[swidth * sheight];

         _renders = commandRenderers;
      }

      private Rectangle _screenSize;
      private Rectangle? _canvasSize;
      private char[] _buffer;

      private readonly List<ICommandRenderer> _renders;

      public Task Render(CancellationToken cancellationToken) {
         // exit (if asked)
         cancellationToken.ThrowIfCancellationRequested();

         // clean the screen 
         Console.Clear();

         // draw the table 
         Console.SetCursorPosition(0, 1);
         Console.Write(_buffer);

         // draw the message last so that the cursor is in the right place for user's input
         Console.SetCursorPosition(0, 0);
         Console.Write(COMMAND_MESSAGE);

         return Task.FromResult(0);
      }

      public async Task Update(CommandParserOutputDto input, CancellationToken cancellationToken) {
         // exit (if asked)
         cancellationToken.ThrowIfCancellationRequested();

         // todo : add validation here 

         if (_renders != null) {
            foreach (var r in _renders) {
               await r.Render(input.Output, _buffer, _screenSize, cancellationToken).ConfigureAwait(false);
            }
         }
      }
   }
}
