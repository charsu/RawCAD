using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Autofac.Extras.Moq;
using NUnit.Framework;
using RawCAD.Core.Models;
using RawCAD.Core.Models.Commands;
using RawCAD.Core.Parsers.Commands;

namespace RawCAD.Tests.Parsers.Commands {
   [TestFixture]
   public class FillCommandTests {
      private readonly CancellationToken _cancellationToken = CancellationToken.None;

      private AutoMock GetMock()
         => AutoMock.GetLoose();

      [Test]
      [TestCase("b 10")]
      [TestCase("b   0 2 ")]
      [TestCase("b 10 2 x ")]
      [TestCase("b 10 2 w2")]
      public async Task Test_NOT_OK(string command) {
         var s = GetMock().Create<FillCommandParser>();

         var r = await s.ParseCommand(command, _cancellationToken);

         Assert.IsFalse(r.WasHandled);
         Assert.IsTrue(r.Output == null);
      }

      [Test]
      [TestCase("b 20 10 o")]
      [TestCase("B 10 10 a")]
      [TestCase(" b 20 10 t")]
      public async Task Test_OK(string command) {
         var s = GetMock().Create<FillCommandParser>();

         var r = await s.ParseCommand(command, _cancellationToken);

         Assert.IsTrue(r.WasHandled);
         Assert.IsTrue(r.Output is FillCommandDto);
      }
   }
}
