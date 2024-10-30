<div id="top"></div>

[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]
<br />
[![Technical Debt](https://sonarcloud.io/api/project_badges/measure?project=alexandrejulien_Peppermint.ReverseProxy&metric=sqale_index)](https://sonarcloud.io/summary/new_code?id=alexandrejulien_Peppermint.ReverseProxy)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=alexandrejulien_Peppermint.ReverseProxy&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=alexandrejulien_Peppermint.ReverseProxy)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=alexandrejulien_Peppermint.ReverseProxy&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=alexandrejulien_Peppermint.ReverseProxy)
[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=alexandrejulien_Peppermint.ReverseProxy&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=alexandrejulien_Peppermint.ReverseProxy)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=alexandrejulien_Peppermint.ReverseProxy&metric=coverage)](https://sonarcloud.io/summary/new_code?id=alexandrejulien_Peppermint.ReverseProxy)
<!-- PROJECT LOGO -->
<br />
<div align="center">
  <!-- <a href="https://github.com/alexandrejulien/Peppermint.ReverseProxy">
    <img src="images/logo.png" alt="Logo" width="80" height="80">
  </a> -->

<h3 align="center">Peppermint Yarp reverse-proxy</h3>

  <p align="center">
    Peppermint is simple and light .NET reverse proxy based on ASP.NET, Kestrel and implement YARP Project by Microsoft (https://github.com/microsoft/reverse-proxy).
    <br />
    <a href="https://github.com/alexandrejulien/Peppermint.ReverseProxy"><strong>Explore the docs »</strong></a>
    <br />
    <br />    ·
    <a href="https://github.com/alexandrejulien/Peppermint.ReverseProxy/issues">Report Bug</a>
    ·
    <a href="https://github.com/alexandrejulien/Peppermint.ReverseProxy/issues">Request Feature</a>
  </p>
</div>



<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <!-- <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#contributing">Contributing</a></li> -->
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project

Peppermint Reverse Proxy is a simple implementation of Microsoft Yarp Project (https://microsoft.github.io/reverse-proxy/). <br />
It's a out of a box version of Microsoft Yarp Project library, intergrated into a light asp.net application.
The objective is to propose a yarp reverse proxy without having to go through a development stage and only the configuration of yarp

Multiples platforms are availables : 
- Portable (.NET Runtime dependency)
- Win (x86 / x64)
- Linux (x64)
- Mac OS (x64)
This a light out of the box reverse-proxy application which can be self hosted with Kestrel Web Server (.NET Web Server) or with a IIS in replacement of ARR (Application Request Routing).
<br />

YARP offers :
- HTTP/2 end to end and gPRC capabilties
- Websockets
- HttpSys delegation (integration with Http.Sys and IIS)
- HTTP/3 with .NET 8
- Loadbalancing
- A/B Switches
- Health Checks
- Transformations
- TLS customizations
- Middlewares
- Logging
- Tracing with OpenTelemetry

<p align="right">(<a href="#top">back to top</a>)</p>

## Benchmarks

YARP reverse proxy offers good performances for many workloads but you will loose on heavy workloads without having more resources.

| Case                                                              | Samples | Average time (ms) | Minimum time (ms) | Max time (ms) | Throughput (HTTP call/sec) | Thread(s) |
|-------------------------------------------------------------------|---------|-------------------|-------------------|---------------|----------------------------|-----------|
| StaticWebApp   - (direct)                                         | 10000   | 0                 | 0                 | 4             |           830,77           | 1         |
| StaticWebApp   - ARR (IIS)                                        | 10000   | 1                 | 0                 | 4             |           635,93           | 1         |
| StaticWebApp -Peppermint Reverse   Proxy (Portable) YARP with IIS | 10000   | 1                 | 0                 | 5             |           627,78           | 1         |
| ApiWebApp   (direct)                                              | 10000   | 0                 | 0                 | 4             |           3935,45          | 1         |
| ApiWebApp - ARR (IIS)                                             | 10000   | 0                 | 0                 | 4             |           1590,07          | 1         |
| ApiWebApp   - PpmintRV Yarp on IIS                                | 10000   | 0                 | 0                 | 5             |           1093,37          | 1         |

### Built With

* [ASP.NET Core](https://github.com/dotnet/aspnetcore)
* [YARP 2.2](https://microsoft.github.io/reverse-proxy/)
* [.NET 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- GETTING STARTED -->
## Getting Started

You have to unzip binairies and configure appsettings.json file

### Prerequisites

You have to install ASP.NET 6, 7, 8 runtime.
In case of using IIS, you have to install it before with ASP.NET 6, 7 Bundle.

### Installation

1. Get latest release
2. Configure "appsettings.json" file



<p align="right">(<a href="#top">back to top</a>)</p>



<!-- USAGE EXAMPLES -->
## Usage

```json
{
  "AllowedHosts": "*",
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Information",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "Serilog": {
    "Using": [ "Serilog.Sinks.File" ],
    "MinimumLevel": "Information",
    "WriteTo": [
      {
        "Name": "File",
        "Args": {
          "path": "proxy-.log",
          "rollingInterval": "Day"
        }
      }
    ]
  },
  "ReverseProxy": {
    "Routes": {
      "route1": {
        "ClusterId": "defaultCluster",
        "Match": {
          "Path": "{**catch-all}"
        },
        "Transforms": [
          { "PathPrefix": "/" },
          { "RequestHeadersCopy": "true" },
          { "RequestHeaderOriginalHost": "false" }
        ]
      }
    },
    "Clusters": {
      "defaultCluster": {
        "Destinations": {
          "destination1": {
            "Address": "https://api.ipify.org/"
          }
        },
        "HttpClient": {
          "DangerousAcceptAnyServerCertificate": "true",
          "EnableMultipleHttp2Connections": "true"
        }
      }
    }
  }
}
```

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- ROADMAP -->
<!-- ## Roadmap

- [ ] Feature 1
- [ ] Feature 2
- [ ] Feature 3
    - [ ] Nested Feature

See the [open issues](https://github.com/alexandrejulien/Peppermint.ReverseProxy/issues) for a full list of proposed features (and known issues).

<p align="right">(<a href="#top">back to top</a>)</p> -->



<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".
Don't forget to give the project a star! Thanks again!

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE.txt` for more information.

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- CONTACT -->
## Contact

Alexandre Julien - [@alexandrejulien](https://twitter.com/alexandrejulien) 

Project Link: [https://github.com/alexandrejulien/Peppermint.ReverseProxy](https://github.com/alexandrejulien/Peppermint.ReverseProxy)

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/alexandrejulien/Peppermint.ReverseProxy.svg?style=for-the-badge
[contributors-url]: https://github.com/alexandrejulien/Peppermint.ReverseProxy/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/alexandrejulien/Peppermint.ReverseProxy.svg?style=for-the-badge
[forks-url]: https://github.com/alexandrejulien/Peppermint.ReverseProxy/network/members
[stars-shield]: https://img.shields.io/github/stars/alexandrejulien/Peppermint.ReverseProxy.svg?style=for-the-badge
[stars-url]: https://github.com/alexandrejulien/Peppermint.ReverseProxy/stargazers
[issues-shield]: https://img.shields.io/github/issues/alexandrejulien/Peppermint.ReverseProxy.svg?style=for-the-badge
[issues-url]: https://github.com/alexandrejulien/Peppermint.ReverseProxy/issues
[license-shield]: https://img.shields.io/github/license/alexandrejulien/Peppermint.ReverseProxy.svg?style=for-the-badge
[license-url]: https://github.com/alexandrejulien/Peppermint.ReverseProxy/blob/master/LICENSE
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://linkedin.com/in/alexandrejulien
[product-screenshot]: images/screenshot.png
