---
page_type: sample
languages:
- csharp
- javascript
- html
- powershell
products:
- azure
description: "Welcome to the Knowledge Mining Solution Accelerator!"
urlFragment: azure-search-knowledge-mining
---

![Knowledge Mining Solution Accelerator](images/kmheader.png)

# Knowledge Mining Solution Accelerator for Azure Government

## About this repository

Welcome to the Knowledge Mining Solution Accelerator! This is based on the [Solution Accelerator](https://github.com/Azure-Samples/azure-search-knowledge-mining) developed for Azure Commercial. 

This accelerator provides developers with all of the resources they need to quickly build an initial Knowledge Mining prototype with [Azure Cognitive Search](https://docs.microsoft.com/azure/search/cognitive-search-concept-intro). Use this accelerator to jump-start your development efforts with your own data or as a learning tool to better understand how you can use Cognitive Search to meet the unique needs of your business.

In this repository, we've provided you with all of the artifacts you need to quickly create a Cognitive Search Solution including: templates for deploying the appropriate Azure resources, assets for creating your first search index, templates for using custom skills, a basic web app, and PowerBI reports to monitor search solution performance. We've infused best practices throughout the documentation to help guide you. With Cognitive Search, you can easily index both digital data (such as documents and text files) and analog data (such as images and scanned documents).

> Note: This guide uses the AI enrichment feature of Cognitive Search. AI enrichment allows you to ingest many kinds of data (documents, text files, images, scanned docs, and more), extract their contents, enrich and transform it, and then index it for exploration purposes. To learn more about this feature, see the [AI in Cognitive Search](https://docs.microsoft.com/azure/search/cognitive-search-concept-intro) doc.

Once you're finished, you'll have a web app ready to search your data.

![A web app showing several resources and their lists of searchable tags](images/ui.PNG)

## Prerequisites

In order to successfully complete your solution, you'll need to gain access and provision the following resources:

* Azure subscription - [Create one for free](https://azure.microsoft.com/free/)
* [Visual Studio 2019 or later](https://visualstudio.microsoft.com/downloads/) - Community edition or higher
* [Postman](https://www.getpostman.com/) for making API calls
* Documents uploaded to any data source supported by Azure Search Indexers. For a list of these, see [Indexers in Azure Cognitive Search](https://docs.microsoft.com/azure/search/search-indexer-overview). This solution accelerator uses Azure Blob Storage as a container for source data files. You can find sample documents in the **sample_documents/** folder.

The directions provided in this guide assume you have a fundamental working knowledge of the Azure portal, Azure Functions, Azure Cognitive Search, Visual Studio and Postman. For additional training and support, please see:

* [Knowledge Mining Bootcamp](https://github.com/MicrosoftLearning/LearnAI-KnowledgeMiningBootcamp)
* [AI in Cognitive Search documentation](https://docs.microsoft.com/azure/search/cognitive-search-resources-documentation)

## Process overview

Clone or download this repository and then navigate through each of these folders in order, following the steps outlined in each of the README files. When you complete all of the steps, you'll have a working end-to-end solution that combines data sources with data enrichment skills, a web app powered by Azure Cognitive Search, and intelligent reporting on user search activity.

![the cognitive indexing pipelines used for processing unstructured data in Azure Search](images/architecture.jpg)

> Note: If you have sensitive content, please note the following:
* The web application that comes with this Solution Accelerator is not configured with authentication provider. So anyone can access the web application if they have the web application URL. If you have sensitive content, you need to restrict the access to the web application.
* Web application access the data in the Blob storage using SAS(Shared access signature) token. When user executes Query, web application generates SAS token for the Search results.

If you have sensitive data please work with your security team to restrict the access. 

### [00 - Resource Deployment](./00%20-%20Resource%20Deployment)

The contents of this folder show you how to deploy the required resources to your Azure subscription. You can do this either through the [Azure portal](https://portal.azure.us) or using the provided [PowerShell script](./00%20-%20Resource%20Deployment/deploy.ps1). Powershell script deploys the whole solution end to end (Resoource Deployment, Search Index Creation and Web UI template deployment)

Alternatively, you can automatically deploy the required resources using this button:

[![Deploy to Azure](images/AzureGov.JPG)](https://portal.azure.us/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2Fusri%2Fazuregov-search-knowledge-mining%2Fmain%2Fazuredeploy.json)

### [01 - Search Index Creation](./01%20-%20Search%20Index%20Creation)

This folder contains a Postman collection that you can use to create a search index. The collection is pre-configured to take advantage of out-of-the-box Cognitive Search functionality.

We recommend using this collection to create an initial search index and then iterating by editing the postman collection and adding custom skills as needed.

### [02 - Web UI Template](./02%20-%20Web%20UI%20Template)

This folder contains a basic Web UI Template, written in .NET Core, which you can configure to query your search index. Follow the steps outlined in the [Web UI Template README file](./02%20-%20Web%20UI%20Template) to integrate your new search index into the web app.


### [Sample Documents](./sample_documents)

This folder contains a small data set in a variety of file formats that you can use to build your solution if you don't have another data set available.

## License

Please refer to [LICENSE](./LICENSE.md) for all licensing information.

## Contributors
+ Ben Hlaban 
+ Brian Pendergrass
+ Dayo Bamikole 
+ Derek Legenzoff
+ Marck Vaisman
+ Mark Tabladillo
+ Richard Posada
+ Samori Augusto
+ Shelly Parker
+ Sreedhar Mallangi
+ Tim Omta
+ Todd Pliner

