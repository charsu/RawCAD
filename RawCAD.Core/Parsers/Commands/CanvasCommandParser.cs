using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using RawCAD.Core.Models;
using RawCAD.Core.Models.Commands;

namespace RawCAD.Core.Parsers.Commands {
   public class CanvasCommandParser : ICommandParser {
      /// <summary>
      /// reg ex with named capture group for quick extraction 
      /// </summary>
      public const string REGEX_EXPR = @"^[\s]*(?<cmd>[c])[\s](?<w>[0-9]*)[\s](?<h>[0-9]*)[\s]*";

      public const string REGEX_EXPRX_COMD = "cmd";
      public const string REGEX_EXPRX_HEIGHT = "h";
      public const string REGEX_EXPRX_WIDTH = "w";

      public Task<CommandParserOutputDto> ParseCommand(string input, CancellationToken cancellationToken) {
         var output = new CommandParserOutputDto();

         if (!string.IsNullOrEmpty(input)) {
            var matches = Regex.Matches(input, REGEX_EXPR, RegexOptions.IgnoreCase);
            foreach (Match m in matches) {
               var command = m.Groups[REGEX_EXPRX_COMD]?.Value;
               var height = m.Groups[REGEX_EXPRX_HEIGHT]?.Value;
               var width = m.Groups[REGEX_EXPRX_WIDTH]?.Value;

               if (!string.IsNullOrEmpty(command)
                  && !string.IsNullOrEmpty(height)
                  && !string.IsNullOrEmpty(width)) {

                  output.WasHandled = true;
                  output.Output = new CanvasCommandDto() {
                     Height = int.Parse(height),
                     Width = int.Parse(width)
                  };

                  break;
               }
            }
         }

         return Task.FromResult(output);
      }
   }
}
