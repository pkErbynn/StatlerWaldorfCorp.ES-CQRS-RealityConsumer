# StatlerWaldorfCorp.ES-CQRS-RealityConsumer

This is a QUERY api service
- Responsible for query to maintain the location of each team member, but the location is only the most recently received location from some application.
- Interacts with the cache only not the Messaging Queue
    - Fetches data published into the Redis cache by the EventProcessor, and deserialize it for query response