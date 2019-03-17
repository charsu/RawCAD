using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Autofac.Extras.Moq;
using NUnit.Framework;
using RawCAD.Core.Models.Commands;
using RawCAD.Core.Parsers.Commands;

namespace RawCAD.Tests.Parsers.Commands {
   [TestFixture]
   public class CanvasCommandTests {
      private readonly CancellationToken _cancellationToken = CancellationToken.None;

      private AutoMock GetMock()
         => AutoMock.GetLoose();

      [Test]
      [TestCase("c 10")]
      [TestCase("c   0")]
      [TestCase("c 10 2w2")]
      public async Task Test_NOT_OK(string command) {
         var s = GetMock().Create<CanvasCommandParser>();

         var r = await s.ParseCommand(command, _cancellationToken);

         Assert.IsFalse(r.WasHandled);
         Assert.IsTrue(r.Output == null);
      }

      [Test]
      [TestCase("c 20 10")]
      [TestCase("C 10 10")]
      [TestCase("c 20 10")]
      public async Task Test_OK(string command) {
         var s = GetMock().Create<CanvasCommandParser>();

         var r = await s.ParseCommand(command, _cancellationToken);

         Assert.IsTrue(r.WasHandled);
         Assert.IsTrue(r.Output is CanvasCommandDto);
      }
   }
}
