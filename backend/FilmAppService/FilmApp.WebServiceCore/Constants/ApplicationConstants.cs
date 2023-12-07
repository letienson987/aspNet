namespace FilmApp.WebServiceCore.Constants;

public static class MessageConstants
{
    public static string BuildDbContextErrorMessage(string tableName, string action, string message) 
        => $"An error while ${action} ${tableName}: ${message}";

    public const string TransactionNotBeenStarted = "Transaction has not been started.";
    public static string ItemNotFound<T>() => $"{nameof(T)} item is not found";
    public const string DupplicateName = $"Name dupplicate, please enter the new name.";
}

public static class DbContextActionConstants
{
    public const string Create = "Create";
    public const string Update = "Update";
    public const string Delete = "Delete";
    public const string GetById = "Get By Id";
    public const string GetAll = "Get All";
    public const string Find = "Find";
    public const int MinOrder = 0;
}