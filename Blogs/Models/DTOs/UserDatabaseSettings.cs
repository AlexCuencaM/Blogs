﻿namespace Blogs.Models.DTOs;

public class UserDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string BooksCollectionName { get; set; } = null!;
}
