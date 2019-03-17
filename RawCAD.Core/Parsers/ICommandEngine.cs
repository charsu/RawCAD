using System.Threading;
using System.Threading.Tasks;
using RawCAD.Core.Models;

namespace RawCAD.Core.Parsers {
   public interface ICommandEngine {
      Task<CommandParserOutputDto> GetNextCommand(CancellationToken cancellationToken);
   }
}