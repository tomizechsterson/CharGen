# CharGen
 
[![Build status](https://ci.appveyor.com/api/projects/status/ny4n8ywn72b17fyy?svg=true&passingText=Build%20and%20tests%20OK&pendingText=Building%20and%20running%20tests&failingText=Build%20and%2For%20tests%20not%20OK)](https://ci.appveyor.com/project/tomizechsterson/chargen)
[![Coverage Status](https://coveralls.io/repos/github/tomizechsterson/CharGen/badge.svg?branch=master)](https://coveralls.io/github/tomizechsterson/CharGen?branch=master)

These services are the backend for the [chargen-ui](https://github.com/tomizechsterson/chargen-ui) ReactJS project, and need to be running for all of that project's features to work. Similarly to the ui project, this is also a toy project that was meant to give me some exposure to:
- Microservices
- DDD

This means that not all the features required to fully create a character for these games will be implemented. However, you're welcome to submit a PR for something that I've left out, if you're so inclined.

## Update (9/15/2018)
At this point, all the features I wanted for this service are implemented and work locally, so I'm calling this good. I likely won't address any created issues, but I should still be able to review any PR's that people create

## Getting Started

I've been developing this on Windows, but using non-Microsoft tools, so this should build and run on all OS's without too much trouble.

### Prerequisites

Be sure to have the latest versions of these installed:
- [Git](https://git-scm.com/)
   - This is what you need to pull the code down to your machine and submit changes to the repo
- [.Net Core](https://www.microsoft.com/net/download) (Make sure to download the SDK, which I believe includes the Runtime)
  - This will allow you to run the `dotnet` commands to start the dev server and compile the project

### Installing

- Make a folder for the code and run `git clone https://github.com/tomizechsterson/CharGen`
  - This will pull down the latest version of the code and copy it into the `CharGen` folder
- Navigate into this folder with your terminal of choice
- Run `dotnet restore` at the root of the project

At this point, the project should be ready to build and run in your IDE of choice. If not, feel free to open an issue and I'll see what I can do.

### Running the Service

To spin up the server so the UI can talk to it, navigate to the root of the project folder and run one of the following, depending on which service you want to start up
- `dotnet run -p ADD2CharacterService`
- `dotnet run -p DD35CharacterService`

## Running the Tests

This project uses [xUnit](https://xunit.github.io/) for unit tests. You can run `dotnet test CharGen.UnitTests` to run the test project from the command line, or use the test runner built into your chosen IDE. Just make sure you have xUnit enabled for them to get picked up.

If you want to see the current coverage, you'll want to run `dotnet test CharGen.UnitTests -c Release -v q /p:CollectCoverage=true /p:Exclude=\"[*]*.Program,[*]*.Startup,[*]*.*Controller,[*]*.*Model,[*]*.*DBSetup,[*]*.GlobalExceptionFilter\"`. This closely mirrors what the CI pipeline does to calculate coverage and report it to Coveralls, but also outputs the results to the console.

## Contributing

If you'd like to contribute, feel free to open a PR with the changes you'd like to make, and I'll be happy to review it. I'll try to get to it promptly, but I make no promises :)

## License

This project is licensed under the GNU General Public License - see the [LICENSE.md](LICENSE.md) file for details
