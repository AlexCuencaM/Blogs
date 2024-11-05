using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Blogs.Models.Entities;

public class Users
{
    [BsonId]
    [BsonElement("_id")]
    public ObjectId Id { get; set; }
    [BsonElement("name")]
    public string Name { get; set; } = null!;
    [BsonElement("age")]
    public int Age { get; set; }
    [BsonElement("email")]
    public string Email { get; set; } = null!;
}
