# Basic Concept
Mentoring focused on building an individual learning path based on the application that the mentee wants to create during the mentoring process. The program includes fixed and variable modules.

**Fixed Theoretical** modules are related to common engineering practices that can be used for building applications in different programming languages and different platforms. Mostly modules are theoretical with practical tasks or examples.

**Variable Practical** modules will be adapted for the toolset that the mentee chooses during the common engineering modules. Different variations of the learning path can then be introduced and explored during the implementation of the mentee's application. This types of modules related to creation of the project and in most cases witout time limitations

**Variable Theoretical** modules to deep dive to technologies and tools have been chosen by menteed on the previous modules. Mostly modules will be theoretical to explain best practices, tooling for the mentee which can be used for mentee's project development

The mentor can also include additional topics to address the mentee's technological or theoretical gaps.

Additionally, mentoring will include fundamental modules that can be chosen for separate sessions.

# Solution/Software Architecture and Engineering Basics (Fixed Theoretical)

Session: **Time: 1.5h**

## Theory

- Solution architecture Goals and Drivers
- Functional Requirements and Correctness
- Quality Attributes and Non-Functional Requirements
- Architecture Significant Requirements (ASR)
- Tactical vs Strategical thinking
- Software delivery options
    - Agile
    - Waterfall
    - Sturtup style
    - Hubrid options

### Reference Materials

**Books**
- [Software Architecture in Practice](https://www.amazon.com/Software-Architecture-Practice-3rd-Engineering/dp/0321815734) by Len Bass, Paul Clements, and Rick Kazman
- [Designing Software Architectures: A Practical Approach](https://www.amazon.com/Designing-Software-Architectures-Practical-Approach/dp/0134390784) by Humberto Cervantes and Rick Kazman

**Links**
- [Architecture Architetcure Guide](https://guidanceshare.com/wiki/Application_Architecture_Guide) Common Free Guide
- [BTABoK](https://btabok.iasaglobal.org/) Free guidance from IATA
- [Goals and Drivers](https://www.linkedin.com/pulse/key-ingredients-drivers-goals-objectives-measures-strategy-amir-jamil)
- [Functional Requirements](https://www.techtarget.com/whatis/definition/functional-requirements) Tech Target
- [Functional Requirements](https://en.wikipedia.org/wiki/Functional_requirement) wiki
- [Non-Functional Requirements](https://en.wikipedia.org/wiki/Non-functional_requirement) wiki
- [Quality Attributes](https://en.wikipedia.org/wiki/List_of_system_quality_attributes) wiki
- [Quality Attributes](https://guidanceshare.com/wiki/Application_Architecture_Guide_-_Chapter_7_-_Quality_Attributes) Architecture Guide
- [ASR](https://en.wikipedia.org/wiki/Architecturally_significant_requirements) wiki
- [ASR](https://iasaglobal.org/Public/Public/TOPICS/Architecturally-Significant-Requirements.aspx) IASA Definition
- [Tactical vs Strategic](https://www.linkedin.com/pulse/architecture-balance-strategic-vs-tactical-david-knott)
- [Tactical vs Strategic Balance](https://martech.org/strategic-vs-tactical-decisions-how-to-find-the-right-balance/)
- [What is Agile developemnt](https://medium.com/@SoftwareDevelopmentCommunity/7-reasons-why-you-should-use-agile-methodologies-for-your-next-software-development-4341257039c6)

**Videos**
- [Functional vs NF ReqDefine basic functional requirements
    - Define basic non-functional requirements
    - Define ASRs
    - Choose definition format applicable for the taskuirements](https://www.youtube.com/watch?v=NRu3pHsgi-c)

## Paractice

    - Define goals and drivers for the practical task
    - Define basic functional requirements
    - Define basic non-functional requirements
    - Define ASRs
    - Choose definition format applicable for the task

# Architecture and Engineering Approaches (Fixed)

Session: **Time: 1.5h**

## Theory

- Classic architecture approaches overview
    - General Solution (Enterprise) Architecture. (IASA, Custom based on books, etc.)
        - TOGAF
        - Zachman Framework
        - ITIL
- Continous Architecture overview
- Theory of invention overview (TRIZ, ARIZ)
- Decision making approaches
    - Pros and Cons analysis
    - Architecture desision record
    - Request For Comments
    - Decision Tree (Block schema)
    - Mind map analysis
    - "Table Analytic" Power of Excel
- Software Delivery Approaches Overview
    - Agile (SCRUM, Kanban)
    - Sturtup style
    - "Excel" planning and delivery
    - Waterfall
    - Hubrid approaches

**Books**
- [Continous architecture in practise](https://www.amazon.co.uk/Continuous-Architecture-Practice-Addison-Wesley-Signature/dp/0136523560)

**Links**
 - [IASA](https://iasaglobal.org/Public/Public/Membership/Welcome_to_Iasa.aspx?hkey=79ff92e9-8ee6-4ae3-a887-631e75c13081)
- [TOGAF](https://www.opengroup.org/togaf)
- [ITIL](https://www.ibm.com/topics/it-infrastructure-library)
- [Continous Architecture](https://continuousarchitecture.com/)
- [Agile Architecture](https://medium.com/@kiptoohesbon/architecture-in-the-age-of-agile-5043abfa7ca5)
- [Decision Making](https://mbanote.org/decision-making/)
- [Decision Tree](https://hbr.org/1964/07/decision-trees-for-decision-making)

**Videos**
- Continous Architecture
    - https://www.youtube.com/watch?v=yN37hfm2ytM
    - https://www.youtube.com/watch?v=6WSrQi66U9U
    - https://www.youtube.com/watch?v=963Ls1X17zs
    - https://www.youtube.com/watch?v=IIy4Adg4WR0

## Paractice

    - Choose architecture approach or practices for the practical task development
    - Choose delivery style and approaches
    - Document decision made (consider pros and cons, understand tradeoffs of the choosen style)

# Architecture Documentation and Knowledge Sharing (Fixed Theoretical)

Session: **Time: 1.5h**

## Theory

- Why do we need to document?
- Formal architecture documentation overview
    - **4 + 1 View**
        - **Logical View**: Describes the system’s functionality.
        - **Development View**: Focuses on software management and configuration.
        - **Process View**: Addresses the system’s dynamic aspects, concurrency, and performance.
        - **Physical View**: Details the physical deployment of the system.
        - **Scenarios**: Illustrates how the views work together through use cases or scenarios.
    - **C4 Model**
        - **Context Diagram**: High-level view of the system, showing it in the context of its environment and external systems.
        - **Container Diagram**: Depicts containers such as applications, databases, and services that compose the system.
        - **Component Diagram**: Breaks down containers into components and describes interactions.
        - **Code Diagram**: Details the internal structure of individual components down to the class level.
    - **Views and Beyond (V&B)**
        - **Primary Presentation**: Graphical representation or other forms of primary documentation.
        - **Element Catalog**: List and description of elements within the view.
        - **Context Diagram**: Depicts how the documented elements fit within the broader context.
        - **Variability Guide**: Shows how the architecture varies and adapts to different conditions.
        - **Rationale**: Explains why certain decisions were made.
    - **TOGAF Architecture Development Method (ADM)**
        - **Architecture Vision**: High-level view of the architecture to guide further steps.
        - **Business Architecture**: Describes business processes and their alignment with the business strategy.
        - **Information Systems Architecture**: Covers data and application architectures.
        - **Technology Architecture**: Details the logical and physical technology architecture.
        - **Opportunities and Solutions**: Identifies and evaluates potential solutions.
    - **Unified Modeling Language (UML)**
        - **Class Diagrams**: Describe the static structure of the system.
        - **Sequence Diagrams**: Illustrate interactions over time.
        - **Use Case Diagrams**: Show the functionality provided by the system in terms of actors and their goals.
        - **State Diagrams**: Represent the state changes of objects.
        - **Activity Diagrams**: Model the workflow and operations.
- Informal and mixed architecture documentation approaches
- Agile documentation approach
    - Just Enough Documentation:
        Produce only the documentation that is necessary and valuable.
        Avoid creating excessive or overly detailed documentation.

    - Living Documentation:
        Documentation evolves with the project and is kept up to date.
        It is frequently reviewed and revised to reflect the current state of the system.

    - Collaboration and Communication:
        Foster collaboration among team members and stakeholders to ensure shared understanding.
        Use documentation as a communication tool rather than an end in itself.

    - Prioritize Working Software:
        Focus on delivering working software over comprehensive documentation.
        Documentation supports the development process rather than dictating it.

    - Minimize Waste:
        Avoid unnecessary or redundant documentation to prevent waste.
        Strive for clarity and conciseness.
- API Documentation overview (SWAGGER, Open API)
- Architecture Documentation Best Practices
    1. Identify Stakeholders
        Understand who will use the documentation (developers, architects, managers, etc.).
        Tailor Content: Customize the level of detail and technicality based on the audience's needs.

    2. Clarity and Simplicity

        Use Clear Language: Avoid jargon and overly complex language.
        Concise Descriptions: Be concise while ensuring completeness.
        Visual Aids: Use diagrams, charts, and other visual tools to simplify complex concepts.

    3. Consistent Structure

        Standardized Formats: Use a consistent format and structure throughout the documentation.
        Templates: Develop templates for different types of documentation to maintain uniformity.

    4. Comprehensive Coverage

        High-Level Overview: Provide a high-level summary of the architecture.
        Detailed Sections: Include detailed descriptions of components, modules, interfaces, and interactions.
        Contextual Information: Explain the context, rationale, and trade-offs behind architectural decisions.

    5. Maintainability

        Living Documentation: Regularly update the documentation to reflect changes in the architecture.
        Version Control: Use version control systems to track changes and maintain historical versions of the documentation.

    6. Accessibility

        Easy Access: Ensure documentation is easily accessible to all stakeholders.
        Searchable: Implement search functionality to help users find information quickly.

    7. Modularity

        Modular Sections: Break down documentation into modular, self-contained sections.
        Cross-Referencing: Use hyperlinks and references to connect related sections.

    8. Use of Visuals

        Diagrams: Include architectural diagrams like flowcharts, sequence diagrams, and component diagrams.
        Annotation: Annotate diagrams to clarify elements and their interactions.

    9. Scenarios and Examples

        Use Cases: Provide practical use cases and examples to illustrate how the architecture works.
        Scenarios: Describe typical scenarios and workflows to demonstrate the architecture in action.

    10. Review and Feedback

        Peer Reviews: Have documentation reviewed by peers to ensure accuracy and completeness.
        Stakeholder Feedback: Collect feedback from stakeholders and continuously improve the documentation.

    11. Tool Support

        Documentation Tools: Use tools like Confluence, SharePoint, or GitHub for creating and maintaining documentation.
        Diagramming Tools: Use tools like Lucidchart, draw.io, or Microsoft Visio for creating diagrams.

    12. Link to Code and Other Artifacts

        Code References: Link documentation to relevant code repositories and other technical artifacts.
        Integrate with Development: Ensure documentation is integrated with the development process and tools.

    13. Security and Compliance

        Sensitive Information: Ensure that sensitive information is properly protected in the documentation.
        Compliance Standards: Adhere to relevant compliance and regulatory standards in the documentation.

    14. Documenting Decisions

        Decision Logs: Maintain a log of architectural decisions, including the reasoning and alternatives considered.
        Impact Analysis: Document the impact of decisions on various aspects of the system.

    15. Documentation as a Product

        Ownership: Assign ownership and responsibility for maintaining the documentation.
        Continuous Improvement: Treat documentation as an evolving product, continuously improving it based on feedback and changes in the system.
- Decision documentation process
    - RFC
    - Architecture Decision Record
    - Pros and Cons analysis
- Documentation practice and usefull methods which can improve knowledge sharing and documentation usage
- Process embedded knowledge sharing practices
    - Backlog items grooming
    - Meetings and effectiveness
    - Communication

**Books**
- [Documenting Software Architectures: Views and Beyond](https://www.amazon.com/Documenting-Software-Architectures-Views-Beyond/dp/0321552687)

**Links**
- [Agile Documentation](https://agilemodeling.com/essays/agiledocumentation.htm)
- [4+1 View](https://en.wikipedia.org/wiki/4%2B1_architectural_view_model)
- [C4 Model](https://en.wikipedia.org/wiki/C4_model)
- [TOGAF](https://pubs.opengroup.org/togaf-standard/introduction/chap02.html)
- [Architecture Decision Records](https://adr.github.io/)

**Videos**
- Agile Documentation:
    - https://www.youtube.com/watch?v=MVhMfdIGMFg
    - https://www.youtube.com/watch?v=J0TbrJkPTs0
    - https://www.youtube.com/watch?v=FYNAqlQB9U4

## Paractice

    - Choose knowledge sharing approach and documentation style

# Architecture and Engineering styles and patterns (Fixed Theoretical)

Session: **Time: 1.5h**

## Theory

- Architecture Styles and Patterns overview
    - Styles vs Patterns
    - SOA
    - Microservice
    - Actors
    - DDD
    - Modular monolith
    - Event Driven Architecture
    - Pipes and filters
    - etc
- Conway's law
- SOLID
- OOP
- GRASP
- Common Patterns
- Why do we need all of this?

**Books**
- [DDD Book](https://www.domainlanguage.com/ddd/blue-book/)
- [Patterns of Enterprise Application Architecture](https://martinfowler.com/books/eaa.html)
- [Actors](https://www.amazon.com/Actors-Concurrent-Computation-Distributed-Systems/dp/026251141X)
- [Reactive Programming](https://www.amazon.com/Reactive-Messaging-Patterns-Actor-Model/dp/0133846830)

**Links**
- [Architecture Styles vs Patters](https://medium.com/@ali.gelenler/architectural-styles-vs-architectural-patterns-7fab51713470)
- [Architecture Styles vs Patters](https://www.geeksforgeeks.org/difference-between-architectural-style-architectural-patterns-and-design-patterns/)
- [Architecture Styles vs Patters](https://medium.com/@mlbors/architectural-styles-and-architectural-patterns-c240f7df88a0)
- [Architecture Styles](https://learn.microsoft.com/en-us/azure/architecture/guide/architecture-styles/)
- [List of patterns](https://en.wikipedia.org/wiki/List_of_software_architecture_styles_and_patterns)
- [Conway's law](https://en.wikipedia.org/wiki/Conway%27s_law)
- [Patterns Basic](https://martinfowler.com/)
- [GoF Patterns](https://en.wikipedia.org/wiki/Design_Patterns)
- [Software Design Patterns](https://en.wikipedia.org/wiki/Software_design_pattern)
- [GRASP](https://en.wikipedia.org/wiki/GRASP_(object-oriented_design)


**Video**
- [Actors](https://www.youtube.com/watch?v=z0N1aZ6SnBk&list=PLJaxDcIXbeDtwZAZcJSzNGMOe2B1l3pYi)
- [Actors Basics](https://www.youtube.com/watch?v=7erJ1DV_Tlo)

## Paractice

    - Choose usefull patterns and architecture styles

# MVP and First Deployment (Variative Practical Module)

Session: **Time: 1.5h**

Practice: **Continous not time limitation**

## Variations
- (Primary) MVP and First Deployment - for simple sturtup like applications and agile developemt
- Detailed project documentation - for emulation of platform design and development, architecture building, accellerators, etc
- Waterfall documentation with detailed execution plan
- *TODO More options in the future*

## Theory
- Continous integration and delivery in agile world
    - Why do we need CI/CD in engineerign and business context?
    - Possible options and tools for CI
        - Jenkins
        - Azure DevOps
        - Github Actions
        - ***Any Mentee can choose and use***
    - Possible option and tools for CD
        - GitOps
        - Azure DevOps
        - Octopus
        - ***Any Mentee can choose and use***
- Infrastructure and Hosting Options
    - Cloud vs On-Prem vs Embedded
    - IaaS vs PaaS vs FaaS (Cloud Option)
    - Database options overview
    - ***Any infrastructure which Mentee gonna to use***

**Links**
[20 CI/CD Tools](https://thectoclub.com/tools/best-ci-cd-tools/)
[50 CI/CD Tools](https://www.cloudzero.com/blog/cicd-tools/)
[Choose Compute Seervices](https://learn.microsoft.com/en-us/azure/architecture/guide/technology-choices/compute-decision-tree)
[Database Comparison](https://db-engines.com/en/)

## Paractice

    - Choose deployment approach and hosting options
    - Choose database and infrastructure required for development
    - Define Sprint 0, 1 goals
    - Define MVP goals
    - Perform first deployment and MVP
    - Continous code, manifests review and gaps capturing
    - Review goals

# API Best Practices (Variative Theoretical Module)

Session: **Time: 1h**

## Theory
- Introduction to APIs
    - What is an API?
    - Categories of APIs (REST, GraphQL, SOAP, WebSockets, etc.)

- History of APIs & Evolution of Technologies
    - Early APIs (1960s–1980s)
        - Concept of subroutines & function libraries
        - RPC (Remote Procedure Call) in early computing
        - Unix system calls as an early form of APIs

    - The Rise of Web APIs (1990s–2000s)
        - SOAP (1998) – XML-based, enterprise adoption
        - REST (2000) – Roy Fielding’s dissertation, lightweight alternative
        - XML-RPC & JSON-RPC – Simplifying API communication

    - Modern APIs & Microservices Era (2010s–Present)
        - GraphQL (2015) – Facebook’s solution for flexible queries
        - WebSockets & Real-time APIs – Enabling two-way communication
        - gRPC (2016) – Google’s efficient, binary protocol for microservices
- REST API Core Principles
- REST API Issues and Limitations
    - Limited queries capabilities
        - Over-fetching: The client receives more data than needed, increasing payload size.
        - Under-fetching: The client receives less data than required, leading to multiple API calls.
    - Lack of Real-Time Communication
        - REST is request-response based, meaning the client must request data, even if nothing has changed.
        - Problem: Not efficient for real-time applications (e.g., chat apps, stock market updates).
    - Stateless Nature Causes Redundant Data Transfers
        - REST APIs are stateless (each request is independent), meaning authentication and session data must be sent on every request.
        - In high-frequency requests, this increases bandwidth usage and slows down performance
    - HTTP Methods Have Limitations
        - Protocol limitation
    - Security Challenges
        - Web based attacks
    - Not Ideal for Microservices Communication
        - Too chatty
- REST API Best Practices
    - Exception and error handling options
    - Meaningful resources identifiers
    - Use correct HTTP Methods
        - PUT vs PATCH for partial and full updates
        - DELETE vs POST for batch deletes
    - Bulk API
    - Versioning approach
        - URI base versioning
        - Headers based versioning
    - HATEOAS concept
    - Cache Responses for Better Performance
    - Implement Rate Limiting & Throttling & Security
    - Optimize Performance with Gzip Compression
- API Management tools and approaches
    - Azure API Management
    - Kong
    - Mulesoft

**Links**
- [What is API?](https://en.wikipedia.org/wiki/API)
- [Categories of API](https://melihsahtiyan.medium.com/what-are-the-types-of-apis-how-does-rest-soap-graphql-works-e135509e9021)
- [Evolution of API](https://medium.com/@keployio/the-evolution-of-apis-a-historical-perspective-fbf4bf765462)
- [SOAP vs REST](https://aws.amazon.com/compare/the-difference-between-soap-rest/)
- [XML-RPC & JSON-RPC](https://en.wikipedia.org/wiki/JSON-RPC)
- [REST Design Principles MS](https://learn.microsoft.com/en-us/azure/architecture/best-practices/api-design)
- [REST API Design](https://en.wikipedia.org/wiki/REST)
- [HATEOAS] (https://en.wikipedia.org/wiki/HATEOAS)

## Practice
    - Develope API for the project

# Microservises Deep Dive Part 1 (Variative Theoretical Module)

Session: **Time: 1.5h**

## Theory
- [Microservises](https://en.wikipedia.org/wiki/Microservices) style overview and why do we need it?
- Microservice style as software complexity management approach
- Properties and typical approaches
    - Service as a single structure unit which connected to other services
    - Organized around business capabilities
    - Technology agnostic
    - Small size of services
    - Messaging enabled
    - [Bounded by context and relations with DDD](https://martinfowler.com/bliki/BoundedContext.html)
    - Autonomous development
    - Individually deployable
- Benefits
    - (Complexity) Easy to implement and understand separate services and component
    - (Integration) Can itegrate services with many other services
    - (Scalability) Can be scaled independently
    - (Deployment) Can be deployed independently with fast timeto market
    - (Low Coupling) Low coupling between services
    - (Recilency) Fault Tolerance
- Conserns
    - Cost of communication
    - Higer testing and deployment efforts
    - Difficult responsibilities segregation
    - Hard transactions management
    - Required high engineering level of organization
    - Required hard contracts negotiation
- Implementation apporaches:
    - [Fowler Characteristics](https://medium.com/design-microservices-architecture-with-patterns/top-10-characteristics-of-microservices-12b046a59bfc)
    - [Netflix Implementation](https://www.youtube.com/watch?v=CZ3wIuvmHeM)
    - [Microsoft Example and Learning](https://github.com/dotnet/eShop)
- Tradeoffs and holly wars
    - Code sharing option:
        - Library vs Service
        - Library vs Copy/Paste
    - Monorepo vs Multirepo
    - Consistency: Eventually consistency vs Strong Consistency
    - Polyghlot technology and persistance vs Monotechnology
- Implementation: How to minimize pros and maximize cons
    - Transform you organization (culture)
        - Microteams
        - Service's ownership
        - Train you team
        - Build governance and laws
    - Build or Buy Ops and Tooling
    - Minimize communication overhead
        - Improve protocols and pipes
    - Design UI/UX
        - Handles eventually consistency
        - Handles asyncronous processes
    - Use proper infrastructure
        - Containerization and orchestration
        - Automate infrastructure creation and support
    - Prepare development environment
        - Ephemeral environments
        - Testing and deployment
    - Use proper service boundary
        - Storage per services
        - Schema management
        - Service communication

**Links**
- [Microsoft Guide](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/)
- [Microservices in Amazon article](https://medium.com/design-microservices-architecture-with-patterns/top-10-characteristics-of-microservices-12b046a59bfc)
- [Microservices style by Fowler](https://martinfowler.com/articles/microservices.html#CharacteristicsOfAMicroserviceArchitecture)
- [Microservices Patterns](https://microservices.io/patterns/index.html)
- [Microservices Shared Library](https://medium.com/duda/shared-libraries-design-and-best-practices-710774ae0bdc)
- [Shared Functionality Library vs Service](https://medium.com/simpplr-technology/microservices-architecture-shared-functionality-library-or-service-69781536dc3e)
- [Monoreo vs Multirepo](https://medium.com/@kazimozkabadayi/choosing-between-monorepo-and-multi-repo-architectures-in-software-development-5b9357334ed2)
- [Monorepo vs Multirepo](https://www.linkedin.com/pulse/monorepo-vs-multi-repos-comprehensive-comparison-frovis)
- [Microservices Tradeoffs](https://martinfowler.com/articles/microservice-trade-offs.html)
- [Service Ownership](https://medium.com/capital-one-tech/cultural-elements-of-microservices-service-ownership-7ff3acea7d92)
- [Backstage](https://backstage.io/)

**Books**
- [Microservices patterns](https://microservices.io/book)

# Microservises Deep Dive Part 2 (Variative Theoretical Module)

- How to organize microservices
    - Service as a single structure unit which connected to other services
    - Organized around business capabilities
    - Small size of services
    - Domain Driven Design Connections
        - [Eric Evans](https://domainlanguage.com/about/)
        - [Martin Fowler](https://www.martinfowler.com/)
        - [The Big Blue Book](https://www.domainlanguage.com/ddd/blue-book/)
        - [Patterns of Enterprise Application Architecture](https://martinfowler.com/eaaCatalog/)
    - [Bounded Context Pattern](https://martinfowler.com/bliki/BoundedContext.html)
    - ORM Usage
- How to syncronize microservices state
    - [Chereography vs Orchestration](https://camunda.com/blog/2023/02/orchestration-vs-choreography/)
    - Distributed Transactions
        - [2F Commit](https://en.wikipedia.org/wiki/Two-phase_commit_protocol)
        - [SAGA + Compensative Transactions](https://learn.microsoft.com/en-us/azure/architecture/patterns/saga)
            - [Mass Transit](https://masstransit.io/)
            - [NServiceBus](https://particular.net/nservicebus)
            - https://github.com/Zio-Net/Sagaway
            - https://github.com/mizrael/OpenSleigh
- Microservices Technology Agnostic
    - [Polygloth persistance](https://martinfowler.com/bliki/PolyglotPersistence.html)
    - General Technology Agnostic
- Deployment and Management
    - Containerization Revolution
    - Infrastructure and Clouds

**Books**
- [Eric Evans](https://domainlanguage.com/about/)
- [Martin Fowler](https://www.martinfowler.com/)

# Additional modules

Additional theoretical modules to close gaps in mentee knowledge

## Garbage Collection Implementation .Net Core

- Basic Memory Management .NET and CLR
    - Memory management evolution history
    - Resources maangement approach
        - Memory
        - CPU (how to make code architecture independent)
        - I/O operations (Files, Networks, etc)
    - Unmanged and Managed memory approach (C#, C, C++)
- Classic Garbage Collection in .NET
    - .NET Heap Types Summary
        | **Heap Type**                    | **Purpose**                               | **Key Features**                                    | **Common Issues**                                  |
        |----------------------------------|--------------------------------|--------------------------------------------------|------------------------------------------------|
        | **Small Object Heap (SOH)**      | Stores small objects (<85KB)   | Generational GC (Gen0, Gen1, Gen2)              | Frequent GC pauses if excessive short-lived objects |
        | **Large Object Heap (LOH)**      | Stores large objects (>85KB)   | Full GC collections, on-demand compaction in .NET 7+ | Memory fragmentation if objects are frequently allocated/released |
        | **Pinned Object Heap (POH)**     | Stores pinned objects (interop) | Objects remain in place, reducing fragmentation | Inefficient memory use if overused |
        | **High-Frequency Heap (Thread-Local Heaps)** | Optimized for multi-threaded workloads | Reduces contention, per-thread allocations | Higher memory usage if too many threads allocate memory |
        | **Native Heap (Unmanaged Memory)** | Stores native (C/C++) allocations | Must be manually freed, used for interop | Memory leaks if not managed properly |
    - High frequency Heap
        - Stores .NET service information like method tables, etc
    - Optimizations of GC
        - GC Compact, use generations
        - Server and Workstation GC
| Feature          | **Workstation GC** 🖥️ | **Server GC** 🔄 |
|----------------|-------------------|-------------------|
| **Threading Model** | Single-threaded GC | Multi-threaded GC (one per core) |
| **Performance** | Optimized for low-latency, UI responsiveness | Optimized for high-throughput, parallel processing |
| **Concurrent GC** | Enabled by default | Can be enabled (improves latency) |
| **Scalability** | Best for single-threaded apps | Best for multi-threaded, high-core systems |
| **Memory Usage** | Lower memory footprint | Higher memory usage (pre-allocates memory per core) |
| **Best For** | GUI apps (WinForms, WPF), low-latency apps | ASP.NET Core, web APIs, cloud, microservices |
        - Large Object Heap Implementation
        - Tiered Compilation
        - Eager Compaction of the Large Object Heap (LOH)
        - Heuristic optimization
    - How to determine when to start GC?
    - Finalization
        - How does finalizer executed?
        - How to use IDisposable for optimization


