using FilmApp.WebServiceCore.Constants;

namespace FilmApp.WebServiceCore.Validation;

public interface IServiceValidation
{
    void ItemNotFoundWillThrowErr<T>(T item);
    void ItemFoundConflictNameWillThrowErr<T>(T item);
}

public class ServiceValidation : IServiceValidation
{
    public void ItemNotFoundWillThrowErr<T>(T item) 
    {
        if (item == null)
            throw new Exception(MessageConstants.ItemNotFound<T>());
    }
    
    public void ItemFoundConflictNameWillThrowErr<T>(T item) 
    {
        if (item != null)
            throw new Exception(MessageConstants.DupplicateName);
    }
}