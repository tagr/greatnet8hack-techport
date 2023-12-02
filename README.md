**#HackTogether**
# The Great .NET 8 Hack: NASA TECHPORT HEADLINES

### Project Goal
> TechPort is used by a wide variety of technology developers, researchers, and managers to identify collaborators, build on prior work, analyze technology gaps, and share knowledge.
> Source: NASA TechPort - [About Us](https://techport.nasa.gov/about)

TechPort hosts NASA's portfolio of active and completed technology projects; it is a valuable online trove for researchers engaged in collaborative, cutting-edge programs supporting the next generation of scientific exploration.

These exciting initiatives deserve to be discovered by today's informed public, as well as tomorrow's scientists and engineers. Using .NET 8, the .NET Aspire cloud native stack, and Azure OpenAI Client Library, I set out to accomplish the following:

1. Create a web application to browse NASA projects using [TechPort API](https://techport.nasa.gov/help/articles/api)
2. Summarize project descriptions into clear, news-style headlines and blurbs
3. Use punchy illustrations to accompany the search result
4. Extract key concepts as search tags to browse additional content
5. Implement a search interface for *ad-hoc* queries
6. 🤡 Explore AI generated humor and 'sensationalize' the headlines

### Author
Andy Merhaut (GitHub: [@tagr](https://github.com/tagr))

### Technologies Applied
* [.NET 8 Framework](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
* [.NET Aspire](https://devblogs.microsoft.com/dotnet/introducing-dotnet-aspire-simplifying-cloud-native-development-with-dotnet-8/)
* [Blazor](https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor)
* [Azure OpenAI Client Library for .NET 1.0.0-beta.9](https://learn.microsoft.com/en-us/dotnet/api/overview/azure/ai.openai-readme?view=azure-dotnet-preview)
* [Tailwind CSS](https://tailwindcss.com/) 3.3.5

### Prerequisites
* Microsoft Visual Studio Community 2022 (at the time of submission was Version 17.9.0 Preview 1.0)
  * [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
  * [Docker Desktop](https://www.docker.com/products/docker-desktop/)
  * [.NET Aspire Workload for Visual Studio](https://learn.microsoft.com/en-us/dotnet/aspire/get-started/quickstart-build-your-first-aspire-app?tabs=visual-studio)

### Setup
* Clone this repository
* Replace the values for `OPENAI_APIKEY` and `OPENAI_API_PROXY_URL` in `greatnet8hack\greatnet8hack.ApiService\Properties\launchSettings.json`
  
### Sample Headlines
![image](https://github.com/tagr/greatnet8hack-techport/assets/1758035/dd429eda-6fc5-4c4d-9371-d777ee392329)
![image](https://github.com/tagr/greatnet8hack-techport/assets/1758035/4667a557-91d7-4074-94ab-713c9e5819c3)
![image](https://github.com/tagr/greatnet8hack-techport/assets/1758035/e53b0ca3-200b-4766-9ec9-0759e43bf719)

### Acknowledgements
* My family's patience
* The [NASA TechPort team](https://techport.nasa.gov/about) for supporting the tools used for this project
* Microsoft for sponsoring the [Great .NET 8 Hack](https://github.com/microsoft/hack-together-dotnet) and providing OpenAI access to participants
* NASA, ESA, CSA, STScI for image of the [Southern Ring Nebula (NIRCam Image)](https://webbtelescope.org/contents/media/images/2022/033/01G70BGTSYBHS69T7K3N3ASSEB?Collection=First%20Images) used as app background
* Event Horizon Telescope collaboration et al. & Britannica for image of [black hole in M87](https://www.britannica.com/place/Virgo-A#/media/1/630116/239625) used in the app
