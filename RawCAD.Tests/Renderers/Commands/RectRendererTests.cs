using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Autofac.Extras.Moq;
using NUnit.Framework;
using RawCAD.Core.Models;
using RawCAD.Core.Models.Commands;
using RawCAD.Core.Renders.Commands;

namespace RawCAD.Tests.Renderers.Commands {
   [TestFixture]
   public class RectRendererTests {
      private readonly CancellationToken _cancellationToken = CancellationToken.None;
      private AutoMock GetMock()
         => AutoMock.GetLoose();

      [Test]
      public async Task Test_OK() {
         var s = GetMock().Create<RectRenderer>();
         var input = new RectCommandDto() { X1 = 0, Y1 = 0, X2 = 2, Y2 = 2 };
         var buffer = new char[9];
         var screen = new System.Drawing.Rectangle(0, 0, 3, 3);

         await s.Render(input, buffer, screen, _cancellationToken);

         Assert.AreEqual(CANVAS_3X3, buffer);
      }

      #region static data 
      static char blank = '\u0000';
      static char[] CANVAS_3X3 = $"xxxx{blank}xxxx".ToCharArray();

      #endregion
   }
}
