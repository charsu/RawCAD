using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RawCAD.Core.Models;

namespace RawCAD.Core.Parsers {
   public interface ICommandParser {
      Task<CommandParserOutputDto> ParseCommand(string input, CancellationToken cancellationToken);
   }
}
