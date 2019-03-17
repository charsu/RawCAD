using System;
using System.Collections.Generic;
using System.Text;

namespace RawCAD.Core.Models {
   public class CommandParserOutputDto {
      public bool WasHandled { get; set; }
      public ICommandDto Output { get; set; }
   }
}
