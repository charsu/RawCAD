using System;
using System.Collections.Generic;
using System.Text;
using RawCAD.Core.Parsers;
using RawCAD.Core.Parsers.Commands;

namespace RawCAD.Core.IoC {
   public class Container {
      public static T Get<T>() where T : class, IEngine
         => new Engine(
            // command parsers 
            new CommandEngine(new List<ICommandParser>() {
               new QuitCommandParser()
            })) as T;
   }
}
