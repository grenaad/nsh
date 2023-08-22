# NSF Food program

To transpile, run

    dotnet fable


Scripts:

    "start": "dotnet tool restore && dotnet fable watch src --runFast vite",
    "build": "dotnet tool restore && dotnet fable src --run vite build",
    "clean": "dotnet fable clean src --yes"

