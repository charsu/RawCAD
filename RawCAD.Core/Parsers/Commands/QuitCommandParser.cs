using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using RawCAD.Core.Models;
using RawCAD.Core.Models.Commands;

namespace RawCAD.Core.Parsers.Commands {
   public class QuitCommandParser : ICommandParser {
      /// <summary>
      /// reg ex with named capture group for quick extraction 
      /// </summary>
      public const string REGEX_EXPR = @"^[\s]*(?<cmd>[q])[\s]*";

      public const string REGEX_EXPRX_COMD = "cmd";

      public Task<CommandParserOutputDto> ParseCommand(string input, CancellationToken cancellationToken) {
         var output = new CommandParserOutputDto();

         if (!string.IsNullOrEmpty(input)) {
            var matches = Regex.Matches(input, REGEX_EXPR, RegexOptions.IgnoreCase);
            foreach (Match m in matches) {
               if (!string.IsNullOrEmpty(m.Groups[REGEX_EXPRX_COMD]?.Value)) {
                  output.WasHandled = true;
                  output.Output = new QuitCommandDto();
                  break;
               }
            }
         }

         return Task.FromResult(output);
      }
   }
}
