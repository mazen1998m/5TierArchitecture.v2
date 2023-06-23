namespace App.core;

public static class Message
{
    public static readonly string NoError = "There are no errors";
    public static readonly string CreateError = "An error occurred in the Create process";
    public static readonly string UnspecifiedError = "There is an unspecified error";
    public static readonly string ValidatorNotFound = "No validators were found ";
    public static readonly string NoPropertyToValidate = "No Property To Validate ";

    public static string NotFound(object obj) => $"this {obj.GetType().Name} is not found";
    public static string NotFound() => "this entity is not found";
}