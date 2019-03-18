# RawCAD

Raw CAD is a raw computer aided design tool

## Current Status

- design based on DI and a raw DI has favored to not add extra setup 
- the design is task based so that it complies with current (modern) design practices
- the design is scalable 
- implemented parsers and renderers for : 
   - line with handling of drawing from any point to any point (not only vertical / horizontal)
   - rectangle - draws a rectangle 
   - fill : allows to fill an area 

- unit tests : 
While the code was not written in a TDD manner (for the most part) basic unit tests were added.
In the case of the fill , which proved to be a little more dificult to test (due to setup) TDD was favored.

Note: more cases should have been tested but due to time constrains they were neglected.

## Future work ?

1. as probabbly noticed the project is missing validations, it assumes that the input is following 
the expected order (eg points start from the top left) and most importantly it should check for canvas 
bounds and crop.

2. in the engine we should have added a step to draw / write a message to inform the user of 
any errors or why a command was not used. 


  
