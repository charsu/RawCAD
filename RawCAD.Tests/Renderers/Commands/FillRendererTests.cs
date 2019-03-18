using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Autofac.Extras.Moq;
using NUnit.Framework;
using RawCAD.Core.Models.Commands;
using RawCAD.Core.Renders.Commands;

namespace RawCAD.Tests.Renderers.Commands {
   [TestFixture]
   public class FillRendererTests {
      private readonly CancellationToken _cancellationToken = CancellationToken.None;
      private AutoMock GetMock()
         => AutoMock.GetLoose();

      [Test]
      public async Task Test_OK() {
         var s = GetMock().Create<FillRenderer>();
         var input = new FillCommandDto() { X = 10, Y = 3, Color = 'o' };
         var buffer = CANVAS_BEFORE_FILL;
         var screen = new System.Drawing.Rectangle(0, 0, 22, 6);

         await s.Render(input, buffer, screen, _cancellationToken);

         Assert.AreEqual(CANVAS_FILLED, buffer);
      }

      #region static data 

      static char blank = '\u0000';

      static char[] CANVAS_BEFORE_FILL = string.Join("", new[] {
         "----------------------",
         "|bbbbbbbbbbbbbbbxxxxx|",
         "|xxxxxxbbbbbbbbbxbbbx|",
         "|bbbbbxbbbbbbbbbxxxxx|",
         "|bbbbbxbbbbbbbbbbbbbb|",
         "----------------------"
      }).Replace('b', blank).ToCharArray();

      static char[] CANVAS_FILLED = string.Join("", new[] {
         "----------------------",
         "|oooooooooooooooxxxxx|",
         "|xxxxxxoooooooooxbbbx|",
         "|bbbbbxoooooooooxxxxx|",
         "|bbbbbxoooooooooooooo|",
         "----------------------"
      }).Replace('b', blank).ToCharArray();


      #endregion
   }


}
