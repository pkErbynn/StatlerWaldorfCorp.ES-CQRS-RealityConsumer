# StatlerWaldorfCorp.ES-CQRS-RealityConsumer
This reality service in Event Sourcing/CQRS serves as the Query service within the CQRS (Command Query Responsibility Segregation) pattern. Its main responsibility is to handle optimized queries, ideally using cached or query-optimized data.

### Responsibilities
- Query Optimization: Provides efficient responses to simple information requests.
- Current Location Data: Returns the most recent location of members based on the latest location reports.

### Key Characteristics
- Current State Focus: This service only exposes the most recent location of members, not the entire event history.
- Not an Event Store: It does not provide access to the full history of location events.

### Architectural Considerations
1. Single Service for Simplicity: In this sample, the query and write responsibilities are not separated for simplicity.
2. Performance Optimization: High-scale architectures might separate query-only and write-only services for better performance.
3. Cache Utilization: Using a distributed cache shared by both query and write services is a recommended optimization, provided the application can handle cache misses and tolerate cache failures.


NB:

This is a QUERY api service
- Responsible for query to maintain the location of each team member, but the location is only the most recently received location from some application.
- Interacts with the cache only not the Messaging Queue
    - Fetches data published into the Redis cache by the EventProcessor, and deserialize it for query response

