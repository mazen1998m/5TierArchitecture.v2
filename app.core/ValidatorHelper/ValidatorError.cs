namespace App.core.ValidatorHelper;

public class ValidatorError
{
    public string PropertyName { get; set; }
    public string ErrorMessage { get; set; }


    public static List<ValidatorError> CreateList() => new();


    public static ValidatorError Create() => new();


    public ValidatorError DefaultValidator()
    {
        PropertyName = Message.ValidatorNotFound;
        PropertyName = Message.NoPropertyToValidate;
        return this;
    }

    public static List<ValidatorError> DefaultError(List<ValidatorError> validator)
    {
        validator.Add(Create().DefaultValidator());
        return validator;
    }
}
