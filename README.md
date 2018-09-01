# Character Generator Services
 
[![Build status](https://ci.appveyor.com/api/projects/status/ny4n8ywn72b17fyy?svg=true&passingText=Build%20and%20tests%20OK&pendingText=Building%20and%20running%20tests&failingText=Build%20and%2For%20tests%20not%20OK)](https://ci.appveyor.com/project/tomizechsterson/chargen)

These services are the backend for this project, and are meant to be called from the [chargen-ui](https://github.com/tomizechsterson/chargen-ui) ReactJS project, and need to be running for all its features to work. This is also a toy project that was meant to get me some exposure to:
- Microservices
- DDD

This means that not all the features required to fully create a character for these games will be implemented. However, you're welcome to submit a PR for something that I've left out, if you're so inclined.

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
- Navigate into this folder with your Git terminal of choice
- Run `dotnet restore` at the root of the project

At this point, the project should be ready to build and run in your IDE of choice. If not, feel free to open an issue and I'll see what I can do.

### Running the Service

To spin up the server so the UI can talk to it, navigate to the root of the project folder and run one of the following, depending on which service you want to start up
- `dotnet run -p ADD2CharacterService`
- `dotnet run -p DD35CharacterService`

## Running the Tests

This project uses [xunit](https://xunit.github.io/) for unit tests. You can run `dotnet test CharGen.UnitTests` to run the test project from the command line, or use the test runner built into your IDE of choice. Just make sure you have xUnit enabled for them to get picked up

## Contributing

If you'd like to contribute, feel free to open a PR with the changes you'd like to make, and I'll be happy to review it. I'll try to get to it promptly, but I make no promises :)

## License

This project is licensed under the GNU General Public License - see the [LICENSE.md](LICENSE.md) file for details