# RawCAD

Raw CAD is a raw computer aided design tool

## Current Status

- Design based on DI and a raw DI has favored to not add extra setup 
- The design is task based so that it complies with current (modern) design practices
- The design is scalable 
- Implemented parsers and renderers for: 
   - Line with handling of drawing from any point to any point (not only vertical / horizontal)
   - Rectangle - draws a rectangle 
   - Fill: allows to fill an area 

- unit tests : 
While the code was not fully written in a TDD manner (for the most part) basic unit tests were added.
In the case of the fill, which proved to be a little more difficult to test (due to setup) TDD was favored.

Note: 
   - More unit tests cases should have been added but due to time constrains they were neglected.
   - The git pattern should have followed branch for feature, but without a visual repository (eg github)
and no other contributors it was decided to go with straight commits to master branch.

## Future work ?

1. as probably noticed the project is missing validations, it assumes that the input is following 
the expected order (eg points start from the top left) and most importantly it should check for canvas 
bounds and crop.

2. in the engine we should have added a step to draw / write a message to inform the user of 
any errors or why a command was not used. 

