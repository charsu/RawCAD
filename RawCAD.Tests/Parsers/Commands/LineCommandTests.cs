﻿using System;
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
   public class LineCommandTests {
      private readonly CancellationToken _cancellationToken = CancellationToken.None;

      private AutoMock GetMock()
         => AutoMock.GetLoose();

      [Test]
      [TestCase("l 10")]
      [TestCase("l   0 2 ")]
      [TestCase("l 10 2 3 ")]
      [TestCase("l 10 2 3 w2")]
      public async Task Test_NOT_OK(string command) {
         var s = GetMock().Create<LineCommandParser>();

         var r = await s.ParseCommand(command, _cancellationToken);

         Assert.IsFalse(r.WasHandled);
         Assert.IsTrue(r.Output == null);
      }

      [Test]
      [TestCase("l 20 10 12 3")]
      [TestCase("L 10 10 2222 1")]
      [TestCase(" l 20 10 20 10")]
      public async Task Test_OK(string command) {
         var s = GetMock().Create<LineCommandParser>();

         var r = await s.ParseCommand(command, _cancellationToken);

         Assert.IsTrue(r.WasHandled);
         Assert.IsTrue(r.Output is LineCommandDto);
      }
   }
}
