using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RawCAD.Core.Models;

namespace RawCAD.Core.Parsers {
   public class CommandEngine : ICommandEngine {
      private readonly List<ICommandParser> _commandParsers;
      internal string lastInput = string.Empty;

      public CommandEngine() {
      }

      public CommandEngine(IList<ICommandParser> commandParsers) {
         _commandParsers = commandParsers?.ToList();
      }

      public async Task<CommandParserOutputDto> GetNextCommand(CancellationToken cancellationToken) {
         var input = Console.ReadLine();
         if (_commandParsers != null) {
            foreach (var p in _commandParsers) {
               var response = await p.ParseCommand(input, cancellationToken).ConfigureAwait(false);
               if (response.WasHandled) {
                  return response;
               }
            }
         }

         lastInput = input;

         return new CommandParserOutputDto() {
            WasHandled = false
         };
      }
   }
}
