# Orchard Core

Orchard Core une réimplémentation d'[Orchard CMS](https://github.com/OrchardCMS/Orchard) en [ASP.NET Core](https://docs.microsoft.com/fr-fr/aspnet/core/). 

Orchard Core se compose de 2 cibles différentes:

- **Orchard Core Framework**: Un framework d'application pour construire des applications **modulaires** et **multi-locataires** en ASP.NET Core.
- **Orchard Core CMS**: Un système de gestion de contenu Web (CMS) construit sur les bases du Framework Orchard Core.

Il est important de noter les différences entre le framework le CMS. Certains développeurs qui veulent déveloper des applications SaaS seront uniquement intéressés par le framework modulaire. Les autres qui veulent construire des sites web administrables se concentreront sur le CMS et construiront des modules pour améliorer leurs sites ou l'écosystème.  

[![Rejoignez le chat sur https://gitter.im/OrchardCMS/OrchardCore](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/OrchardCMS/OrchardCore?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)
[![BSD-3-Clause License](https://img.shields.io/badge/license-BSD--3--Clause-blue.svg)](https://github.com/OrchardCMS/OrchardCore/blob/master/LICENSE)
[![Documentation](https://readthedocs.org/projects/orchardcorefr/badge/)](https://orchardcorefr.readthedocs.io/en/latest/)
[![Crowdin](https://d322cqt584bo4o.cloudfront.net/orchard-core/localized.svg)](https://crowdin.com/project/orchard-core)

## Construire des solutions Software as a Service (SaaS) avec le Framework Orchard Core

Il est très important de comprendre que le Framework Orchard Core est distribué indépendamment du CMS sur nuget.org. Nous avons créé des exemples d'applications sur <https://github.com/OrchardCMS/OrchardCore.Samples> qui vous guideront sur la façon de construire des applications **modulaires** et **multi-locataires** en utilisant juste le Framework Orchard Core sans aucune fonctionnalité CMS spécifique.

Un de nos objectifs est de mettre en place des écosystèmes basés sur la communité d'applications hébergées qui peuvent être étendues avec des modules, comme des systèmes e-commerce, des moteurs de blog et plus encore. Le Framework Orchard Core permet un environnement modulaire qui permet à différentes équipes de travailler sur des parties séparées d'une application et rend les composants réutilisables au travers des projets.

## Construire un site web avec Orchard Core CMS

Orchard Core CMS est réimplémentation complète d'Orchard CMS en ASP.NET Core. Il ne s'agit pas juste d'un portage car nous voulions améliorer la performance de manière drastique et s'aligner le plus possible sur les modèles de développement d'ASP.NET Core.

- **Performance**. This might the most obvious change when you start using Orchard Core CMS. It’s extremely fast for a CMS. So fast that we haven’t even cared about working on an output cache module. To give you an idea, without caching Orchard Core CMS is around 20 times faster than the previous version.

- **Portable**. You can now develop and deploy Orchard Core CMS on Windows, Linux and macOS. We also have Docker images ready for use.

- **Document database** abstraction. Orchard Core CMS still requires a relational database, and is compatible with SQL Server, MySQL, PostgreSQL and SQLite, but it’s now using a document abstraction (YesSql) that provides a document database API to store and query documents. This is a much better approach for CMS systems and helps performance significantly.

- **NuGet Packages**. Modules and themes are now shared as NuGet packages. Creating a new website with Orchard Core CMS is actually as simple as referencing a single meta package from the NuGet gallery. It also means that updating to a newer version only involves updating the version number of this package.

- **Live preview**. When editing a content item, you can now see live how it will look like on your site, even before saving your content. And it also works for templates, where you can browse any page to inspect the impact of a change on templates as you type it.

- **Liquid templates support**. Editors can safely change the HTML templates with the Liquid template language. It was chosen as it’s both very well documented (Jekyll, Shopify, …) and secure.

- **Custom queries**. We wanted to provide a way for developers to access all their data as simply as possible. We created a module that lets you create custom ad-hoc SQL and Lucene queries that can be re-used to display custom content, or exposed as API endpoints. You can use it to create efficient queries, or expose your data to SPA applications.

- **Deployment plans**. Deployment plans are scripts that can contain content and metadata to build a website. You can now include binary files, and even use them to deploy your sites remotely from a staging to a production environment for instance. They can also be part of NuGet Packages, allowing you to ship predefined websites.

- **Scalability**. Because Orchard Core is a multi-tenant system, you can host as many websites as you want with a single deployment. A typical cloud machine can then host thousands of sites in parallel, with database, content, theme and user isolation.

- **Workflows**. Create content approval workflows, react to webhooks, take actions when forms are submitted, and any other process you'd like to implement with a user friendly UI.

- **GraphQL**. We provide a very flexible GraphQL API, such that any authorized external application can reuse your content, like SPA applications or static site generators.

### Différentes stratégies de construction de site web 

Orchard Core CMS supports all major site building strategies:

- **Full CMS**. In this mode, the website uses a theme and templates to render your content, aiming for little to no custom development at all.

- **Decoupled CMS**. The site starts off blank, apart from the content management back-end. You create all the templates you need with Razor Pages or MVC actions and access your content via the content services.

- **Headless CMS**. The site only manages the content, and you create a separate application that will fetch the managed content using GraphQL or REST APIs.

## Statut

The latest released version of Orchard Core is `1.0.0-rc1`.
The release notes can be found on <https://github.com/OrchardCMS/OrchardCore/releases/tag/1.0.0-rc1>

The software is almost ready for final release. No feature development or enhancement of the software is undertaken; tightly scoped bug fixes are the only code you're allowed to write in this phase, and even then only for the most heinous and debilitating of bugs.

Here is a more detailed [roadmap](https://github.com/OrchardCMS/OrchardCore/wiki/Roadmap).

## Démarrer

- Clone the repository using the command `git clone https://github.com/OrchardCMS/OrchardCore.git` and checkout the `master` branch for the latest release, or the `dev` branch for the cutting-edge version.

- Watch the ASP.NET Community Standup video where Orchard Core was demonstrated: <https://www.youtube.com/watch?v=HeDjv3blBjQ&t=2246s&list=PL1rZQsJPBU2StolNg0aqvQswETPcYnNKL&index=24> 

- Follow the samples on <https://github.com/OrchardCMS/OrchardCore.Samples> that will guide you on how to build **modular** and **multi-tenant** applications

### Ligne de commande

- Install the latest versions (current) for both Runtime and SDK of .NET Core from this page <https://www.microsoft.com/net/download/core>
- Navigate to `D:\OrchardCore\src\OrchardCore.Cms.Web` or wherever your respective folder is on the command line in Administrator mode.
- Call `dotnet run`.
- Then open the `http://localhost:5000` URL in your browser.

You can also read the [Code Generation Templates documentation](./docs/templates/) to create new applications from predefined templates.

### Visual Studio 2017

- Download Visual Studio 2019 (any edition) from <https://www.visualstudio.com/downloads/>.
- Open `OrchardCore.sln` and wait for Visual Studio to restore all Nuget packages.
- Ensure `OrchardCore.Cms.Web` is the startup project and run it.
- Optionally install the [Lombiq Orchard Visual Studio Extension](https://marketplace.visualstudio.com/items?itemName=LombiqVisualStudioExtension.LombiqOrchardVisualStudioExtension) to add some useful utilities to your Visual Studio such as an error log watcher or a dependency injector.

### Docker

- Run `docker run --name orchardcms orchardproject/orchardcore-cms-linux:latest`

Docker images and parameters can be found at <https://hub.docker.com/u/orchardproject/>
