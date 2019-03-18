using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using RawCAD.Core.Models;
using RawCAD.Core.Models.Commands;
using System.Linq;

namespace RawCAD.Core.Parsers.Commands {
   public class FillCommandParser : ICommandParser {
      /// <summary>
      /// reg ex with named capture group for quick extraction 
      /// </summary>
      public const string REGEX_EXPR = @"^[\s]*(?<cmd>[b])[\s](?<x>[0-9]*)[\s](?<y>[0-9]*)[\s](?<c>[a-z])[\s]*$";

      public const string REGEX_EXPRX_COMD = "cmd";
      public const string REGEX_EXPRX_X = "x";
      public const string REGEX_EXPRX_Y = "y";
      public const string REGEX_EXPRX_COLOR = "c";
      public readonly static List<char> NOT_ALLOWED_CHARS = new List<char>() { 'x', '|', '-' };

      public Task<CommandParserOutputDto> ParseCommand(string input, CancellationToken cancellationToken) {
         var output = new CommandParserOutputDto();

         if (!string.IsNullOrEmpty(input)) {
            var matches = Regex.Matches(input, REGEX_EXPR, RegexOptions.IgnoreCase);
            foreach (Match m in matches) {
               var command = m.Groups[REGEX_EXPRX_COMD]?.Value;
               var x = m.Groups[REGEX_EXPRX_X]?.Value;
               var y = m.Groups[REGEX_EXPRX_Y]?.Value;
               var c = m.Groups[REGEX_EXPRX_COLOR]?.Value;

               if (!string.IsNullOrEmpty(command)
                  && !string.IsNullOrEmpty(x)
                  && !string.IsNullOrEmpty(y)
                  && !string.IsNullOrEmpty(c)
                  && NOT_ALLOWED_CHARS.All(chr => !c.Contains(chr))) {

                  output.WasHandled = true;
                  output.Output = new FillCommandDto() {
                     X = int.Parse(x),
                     Y = int.Parse(y),
                     Color = char.Parse(c)
                  };

                  break;
               }
            }
         }

         return Task.FromResult(output);
      }
   }
}
