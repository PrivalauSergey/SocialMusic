# Basic Concept
Mentoring focused on building an individual learning path based on the application that the mentee wants to create during the mentoring process. The program includes fixed and variable modules.

Fixed modules are related to common engineering practices that can be used for building applications in different programming languages and on different platforms.

Variable modules will be adapted for the toolset that the mentee chooses during the common engineering modules. Different variations of the learning path can then be introduced and explored during the implementation of the mentee's application.

The mentor can also include additional topics to address the mentee's technological or theoretical gaps.

Additionally, mentoring will include fundamental modules that can be chosen for separate sessions.

# Solution/Software Architecture and Engineering Basics (Fixed)

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
- [Fundamentals of Software Architecture: An Engineering Approach](https://www.amazon.com/Fundamentals-Software-Architecture-Comprehensive-Characteristics/dp/1492043451) by Mark Richards and Neal Ford
- [Software Architecture: The Hard Parts: Modern Trade-Off Analyses for Distributed Architectures](https://www.amazon.com/Software-Architecture-Trade-Off-Distributed-Architectures/dp/1492086894) by Neal Ford, Mark Richards, Pramod Sadalage and Zhamak Dehghani

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

# Architecture Documentation and Knowledge Sharing (Fixed)

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

# Architecture and Engineering styles and patterns (Fixed)

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

# MVP and First Deployment (Variative Module)

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
    - Implement CI/CD process for application MVP
    - The result of this modulw should be working MVP application which can be continously delivered nd deployed
    - Review code and deplyment manifests
