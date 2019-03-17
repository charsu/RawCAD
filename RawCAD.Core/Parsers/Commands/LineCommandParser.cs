using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using RawCAD.Core.Models;
using RawCAD.Core.Models.Commands;

namespace RawCAD.Core.Parsers.Commands {
   public class LineCommandParser : ICommandParser {
      /// <summary>
      /// reg ex with named capture group for quick extraction 
      /// </summary>
      public const string REGEX_EXPR = @"^[\s]*(?<cmd>[l])[\s](?<x1>[0-9]*)[\s](?<y1>[0-9]*)[\s](?<x2>[0-9]*)[\s](?<y2>[0-9]*)[\s]*$";

      public const string REGEX_EXPRX_COMD = "cmd";
      public const string REGEX_EXPRX_X1 = "x1";
      public const string REGEX_EXPRX_Y1 = "y1";
      public const string REGEX_EXPRX_X2 = "x2";
      public const string REGEX_EXPRX_Y2 = "y2";

      public Task<CommandParserOutputDto> ParseCommand(string input, CancellationToken cancellationToken) {
         var output = new CommandParserOutputDto();

         if (!string.IsNullOrEmpty(input)) {
            var matches = Regex.Matches(input, REGEX_EXPR, RegexOptions.IgnoreCase);
            foreach (Match m in matches) {
               var command = m.Groups[REGEX_EXPRX_COMD]?.Value;
               var x1 = m.Groups[REGEX_EXPRX_X1]?.Value;
               var y1 = m.Groups[REGEX_EXPRX_Y1]?.Value;
               var x2 = m.Groups[REGEX_EXPRX_X2]?.Value;
               var y2 = m.Groups[REGEX_EXPRX_Y2]?.Value;

               if (!string.IsNullOrEmpty(command)
                  && !string.IsNullOrEmpty(x1)
                  && !string.IsNullOrEmpty(y1)
                  && !string.IsNullOrEmpty(x2)
                  && !string.IsNullOrEmpty(y2)) {

                  output.WasHandled = true;
                  output.Output = new LineCommandDto() {
                     X1 = int.Parse(x1),
                     Y1 = int.Parse(y1),
                     X2 = int.Parse(x2),
                     Y2 = int.Parse(y2)
                  };

                  break;
               }
            }
         }

         return Task.FromResult(output);
      }
   }
}
