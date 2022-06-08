# Why this approach
Used .NET 6.0 as I'm comfortable with it and I find it easy. If I'm asked to use different development tool it will take longer and can't guarantee the quality.

Did it in many components as this is the standard approach and it makes sense for maintainability. Classes are logically grouped. Layers are pretty standard, API, Services and Integration (separation of concern). Some can argue its like presentation, business and data access layers.

Used NewtonSoft library to do translation from xml to json format. No point re-inventing the wheel.

# Deployment
Ideally, just use what's currently available. Makes it easier for other people in the team or product group to understand it as its not or too different.

One common is the use of Jenkins or Team city that has pipelines with agents the does the build, run tests and publishing of package to a repository. Then we have Octopus Deploy that can do the deployment and target different environments. Variables are great and not to worry about having the right values of configuration. For example, the URL for the existing backend xml service.

On premise and cloud are both option. But recent trend everyone is moving to cloud services due to ease of scalability. (just pay more!) Only downside of this is if services are down and it happened many times before. Its on the news and have have no control over this.

# Documentation
Readme is the way to go. This is really useful when someone has to do some work on your repository. It could be how to setup the development environment like scripts to run, dependencies and diagrams of components and how they interact. If its like a library, show some examples on how to use of it.

Another option would be to add comments on code with specially on areas with complicated business logic like accounting.

Confluence/Wiki is good. You can use third party components to create diagrams, mock UI and more.

Good comment when committing code changes is another one, add ticket on it (JIRA number/id) for ease of reference.

# Components
## API
Where the controller sits with end point exposed for client consumption.

## Services
Service layer, the MWNZCompaniesService is essentially just a wrapper for MWNZCompaniesClient.

## Models
Contains all the "Schema" part of the Open API specification. Company and Error.

## Integration
This is the client or the proxy project which connects to the [existing backend xml service](https://github.com/ncinco/evaluation-instructions/blob/feature/xml-api-and-companies-openapi-spec/xml-api/openapi-xml.yaml). It contains the configuration class which hold the URL for the service.

## Tests
I used nUnit and Moq framework. I'm just used to them and they are easy to use. Just did the Controller part for demo.
